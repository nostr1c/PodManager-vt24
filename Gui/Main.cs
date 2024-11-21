using Controllers;
using System.ComponentModel;
using Models;
using System.Xml;
using System.Diagnostics;
using System.Windows.Forms;
using System.Configuration;

namespace Gui
{
    public partial class Main : Form
    {
        private readonly PodController podController;
        private readonly CategoryController categoryController;
        private readonly BindingList<Pod> podsBindingList;
        private readonly Category emptyCategory;

        public Main()
        {
            InitializeComponent();
            podController = new PodController();
            categoryController = new CategoryController();
            podsBindingList = new BindingList<Pod>();
            emptyCategory = categoryController.GetCategories().Single(category => category.Name == "<No Category>");
            dgPod.DataSource = podsBindingList;
            dgPod.DataBindingComplete += EditColumns;

            PopulatePodTable();
            PopulateCategories();

            podController.NewPodEventHandler += AddPodToTable;
            podController.DeletePodEventHandler += DeletePodFromTable;
            podController.UpdatePodEventHandler += UpdatePodInTable;

            categoryController.NewCategoryEventHandler += AddCategory;
            categoryController.DeleteCategoryEventHandler += DeleteCategory;
            categoryController.UpdateCategoryEventHandler += UpdateCategory;
        }

        private void AddPodToTable(object? sender, PodEventArgs args)
        {
            podsBindingList.Add(args.Pod);
        }

        private void DeletePodFromTable(object? sender, PodEventArgs args)
        {
            int index = podsBindingList.IndexOf(podsBindingList.Single((pod) => pod.Guid == args.Pod.Guid));
            podsBindingList.RemoveAt(index);
        }

        private void UpdatePodInTable(object? sender, PodEventArgs args)
        {
            int index = podsBindingList.IndexOf(podController.GetAllPods().Single(pod => pod.Guid == args.Pod.Guid));
            if (index == -1) return;

            podsBindingList[index] = args.Pod;
        }

        private void AddCategory(object? sender, CategoryEventArgs args)
        {
            lbCategories.Items.Add(args.Category);
            cbCategory.Items.Add(args.Category);
            cbFilter.Items.Add(args.Category);
        }

        private void DeleteCategory(object? sender, CategoryEventArgs args)
        {
            // DataGrid Pods
            podsBindingList.Where(pod => pod.Category?.Name == args.Category.Name)
                           .ToList()
                           .ForEach(pod => pod.Category = emptyCategory);

            // ListBox Categories
            int lbIndex = lbCategories.Items.IndexOf(args.Category);
            lbCategories.Items.RemoveAt(lbIndex);

            // ComboBox Categories
            int cbIndex = cbCategory.Items.IndexOf(args.Category);
            cbCategory.Items.RemoveAt(cbIndex);

            // ComboBox Filter  
            int cbFilterIndex = cbFilter.Items.IndexOf(args.Category);
            cbFilter.Items.RemoveAt(cbFilterIndex);

            podsBindingList.ResetBindings();
        }

        private void UpdateCategory(object? sender, CategoryEventArgs args)
        {
            // ListBox Categories
            int lbIndex = lbCategories.Items.IndexOf(args.Category);
            lbCategories.Items[lbIndex] = args.Category;

            Category originalCategory = categoryController.GetCategories().Single(x => x.Guid == args.Category.Guid);

            // ComboBox Categories
            int cbIndex = cbCategory.Items.IndexOf(originalCategory);
            cbCategory.Items[cbIndex] = args.Category;

            // ComboBox filter
            int cbFilterIndex = cbFilter.Items.IndexOf(originalCategory);
            cbFilter.Items[cbFilterIndex] = args.Category; 

            podsBindingList.ResetBindings();
        }

        private void PopulatePodTable()
        {
            podController.GetAllPods().ForEach(pod => podsBindingList.Add(pod));
        }

        private void PopulateCategories()
        {
            // ListBox Categories
            categoryController.GetCategories()
                .Where(x => x.Name != emptyCategory.Name)
                .ToList().ForEach(category => lbCategories.Items.Add(category));

            // ComboBox Categories
            cbCategory.Items.Add(emptyCategory);
            cbCategory.SelectedItem = emptyCategory;

            categoryController.GetCategories()
                .Where(x => x.Name != emptyCategory.Name)
                .ToList()
                .ForEach(category => cbCategory.Items.Add(category));


            // ComboBox Filter 
            Category allCategories = new Category() { Guid = Guid.NewGuid(), Name = "All categories" };

            cbFilter.Items.Add(allCategories);
            cbFilter.SelectedItem = allCategories;
            categoryController.GetCategories().ForEach(category => cbFilter.Items.Add(category));
        }

        private void Unselect()
        {
            dgPod.CurrentCell = null;
            tbUrl.Text = "";
            tbName.Text = "";
            cbCategory.SelectedIndex = 0;
            lbEpisodes.DataSource = null;
            tbEpisodeDescription.Text = "";
        }

        private Pod? GetSelectedPod()
        {
            var currentRow = dgPod.CurrentRow;

            if (currentRow == null || !currentRow.Selected || currentRow.DataBoundItem == null) return null;

            return (Pod)currentRow.DataBoundItem;
        }

        private Category? GetSelectedCategory()
        {
            if (lbCategories.SelectedItem == null) return null;

            return (Category)lbCategories.SelectedItem;
        }

        private void EditColumns(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgPod.Columns["Guid"] != null) dgPod.Columns.Remove("Guid");
            if (dgPod.Columns["Url"] != null) dgPod.Columns.Remove("Url");

            dgPod.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgPod.Columns["Category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Pod interactions

        private async void BtnAddPod_Click(object sender, EventArgs e)
        {
            if (podController.GetAllPods().Exists(pod => pod.Url == tbUrl.Text)) return;

            try
            {
                Category? category = (Category)cbCategory.SelectedItem;
                await podController.FetchRssAsync(tbUrl.Text, category, tbName.Text);
                Unselect();
            }
            catch (HttpRequestException)
            {
                MessageBox.Show($"{tbUrl.Text} is not a valid URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (XmlException)
            {
                MessageBox.Show($"{tbUrl.Text} is not a RSS-Feed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Someting went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemovePod_Click(object sender, EventArgs e)
        {
            var podToRemove = GetSelectedPod(); if (podToRemove == null) return;

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {podToRemove.Title}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            podController.Delete(podToRemove);
            Unselect();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Pod? podToUpdate = GetSelectedPod();
            Category? category = (Category?)cbCategory.SelectedItem;

            if (podToUpdate == null) return;
            if (string.IsNullOrWhiteSpace(tbName.Text)) return;

            podToUpdate.Title = tbName.Text;
            podToUpdate.Category = category;

            podController.Update(podToUpdate);
            categoryController.ChangePodCategory(category, podToUpdate);

            Unselect();
        }

        private void dgPod_SelectionChanged(object sender, EventArgs e)
        {
            Pod? pod = GetSelectedPod();

            if (pod == null) return;
            tbUrl.Text = pod.Url;
            tbName.Text = pod.Title;
            cbCategory.SelectedItem = pod.Category;

            lbEpisodes.DataSource = pod.Episodes;
        }

        // Category interactions

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCategory.Text)) return;

            try
            {
                categoryController.AddCategory(tbCategory.Text);
            }
            catch (CategoryAlreadyExistsException)
            {
                MessageBox.Show($"The {tbCategory.Text} category already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCategoryRemove_Click(object sender, EventArgs e)
        {
            Category? category = GetSelectedCategory();
            if (category == null) return;

            DialogResult result = MessageBox.Show($"Are you sure you want to delete category {category.Name}.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            categoryController.RemoveCategory(category);

            podController.GetAllPods().Where(pod => pod.Category?.Guid == category.Guid).ToList().ForEach(podToUpdate =>
            {
                podToUpdate.Category = emptyCategory;
                podController.Update(podToUpdate);
            });
        }

        private void btnCategorySave_Click(object sender, EventArgs e)
        {
            Category? category = GetSelectedCategory();
            if (category == null) return;

            try
            {
                categoryController.ChangeCategoryName(category, tbCategory.Text);

                cbFilter.SelectedIndex = 0;

                podController.GetAllPods().Where(pod => pod.Category?.Guid == category.Guid).ToList().ForEach(podToUpdate =>
                {
                    podToUpdate.Category = category;
                    podController.Update(podToUpdate);
                });
            }
            catch (CategoryNameException)
            {
                MessageBox.Show($"The new name {tbCategory.Text} may not be the same as the old one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCategory.Text = GetSelectedCategory()?.Name;
        }

        private void tbUrl_Click(object sender, EventArgs e)
        {
            Unselect();
        }

        private void lbEpisodes_SelectedValueChanged(object sender, EventArgs e)
        {
            Episode? episode = (Episode?)lbEpisodes.SelectedItem;
            if (episode == null) return;

            tbEpisodeDescription.Text = episode.Description;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // få ut vilken är selected,
            // visa alla i tabellen med linq where eller nått fräsigt.  kolla om "alla" är selected, isåfal visa alla

            Category? filterCategory = (Category?) cbFilter.SelectedItem;
            if (filterCategory == null) return;

            podsBindingList.Clear();

            if (filterCategory.Name == "All categories")
            {
                PopulatePodTable();
            }
            else
            {
                podController.GetAllPods()
                             .Where(x => x.Category?.Name == filterCategory.Name)
                             .ToList().ForEach(pod => podsBindingList.Add(pod));
            }
        }
    }
}

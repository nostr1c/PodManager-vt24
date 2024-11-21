using Models;

namespace Controllers
{
    public class PodEventArgs : EventArgs
    {   
        public Pod Pod { get; private set; }

        public PodEventArgs(Pod pod)
        { 
            Pod = pod;
        }
    }
}
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchSQL
{
    public partial class frmWait : Form
    {
        //private readonly Action _action;
       
        public frmWait()
        {
            InitializeComponent();

            
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);

        //    Task.Factory.StartNew(_action).ContinueWith(t => { this.Dispose(); }, TaskScheduler.FromCurrentSynchronizationContext());
        //}
    }
}

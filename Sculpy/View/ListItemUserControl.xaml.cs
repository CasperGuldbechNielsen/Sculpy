using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Sculpy.View
{
    /// <summary>
    /// This class is a UserControl and represents the layout of one item from the ListView of Sculptures from the SculpturesView Page.
    /// </summary>
    public sealed partial class ListItemUserControl : UserControl
    {
        /// <summary>
        /// We need to set the Bindings also in order to access the Model.
        /// </summary>
        public Model.Sculpture Sculpture => this.DataContext as Model.Sculpture;

        public ListItemUserControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }
    }
}

using System.Linq;
using Xceed.Wpf.AvalonDock.Layout;

namespace FileManager.ui
{

    internal class UpdateStrategy : ILayoutUpdateStrategy
    {
        public bool BeforeInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableToShow,
            ILayoutContainer destinationContainer)
        {
            //AD wants to add the anchorable into destinationContainer
            //just for test provide a new anchorablepane 
            //if the pane is floating let the manager go ahead
            LayoutAnchorablePane destPane = destinationContainer as LayoutAnchorablePane;
            if (destinationContainer != null)
            {
                //destinationContainer.RemoveChild(anchorableToShow);
            }
            return false;

        }


        public void AfterInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableShown)
        {
        }


        public bool BeforeInsertDocument(LayoutRoot layout, LayoutDocument anchorableToShow,
            ILayoutContainer destinationContainer)
        {
            return false;
        }

        public void AfterInsertDocument(LayoutRoot layout, LayoutDocument anchorableShown)
        {

        }
    }
}
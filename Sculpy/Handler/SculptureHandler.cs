using Windows.Foundation.Metadata;
using Sculpy.Model;
using Sculpy.ViewModel;

namespace Sculpy.Handler
{
    public class SculptureHandler
    {
        public static async void DeleteSculpture(int id)
        {
            await new Persistancy.PersistenceFacade().DeleteSculptureAsync(id);
            SculpturesHandler.ResetCollectionAsync();
        }

        public static async void UpdateSculpture(Sculpture sculpture)
        {
            await new Persistancy.PersistenceFacade().UpdateSculptureAsync(sculpture);
            SculpturesHandler.ResetCollectionAsync();
        }

        public static async void CreateSculpture(Sculpture sculpture)
        {
            await new Persistancy.PersistenceFacade().CreateSculptureAsync(sculpture);
            SculpturesHandler.ResetCollectionAsync();
        }

    }
}
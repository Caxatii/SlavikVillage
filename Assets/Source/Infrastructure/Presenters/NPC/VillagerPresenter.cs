using Source.ContractInterfaces;
using Source.Domain.Village.Villagers;

namespace Source.Infrastructure.Presenters.NPC
{
    public class VillagerPresenter : IModule
    {
        private IVillager _model;
        private IAnimatedView _view;

        public VillagerPresenter(IVillager model, IAnimatedView view)
        {
            _model = model;
            _view = view;
        }

        public void Initialize()
        {
            _model.Task.Changed += OnTaskChanged;
        }

        private void OnTaskChanged(TaskType taskType)
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
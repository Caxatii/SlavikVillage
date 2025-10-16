using Source.Domain.Village.Villagers;

namespace Source.Application.DataTransfer
{
    public struct SexPairData
    {
        public IVillager First { get; private set; }
        public IVillager Second { get; private set; }

        public bool CanSex() => 
            First != null && Second != null;

        public void Set(IVillager villager)
        {
            if (First == null)
                First = villager;
            else if (Second == null)
                Second = villager;
        }
    }
}
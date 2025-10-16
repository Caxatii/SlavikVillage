using Source.Domain.Resources;

namespace Source.Application.DataTransfer
{
    public readonly struct ResourceData
    {
        public readonly int Value;
        public readonly ResourceType Type;

        public ResourceData(int value, ResourceType type)
        {
            Value = value;
            Type = type;
        }
    }
}
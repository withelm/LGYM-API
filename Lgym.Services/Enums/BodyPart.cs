using Lgym.Resources.Attributes;

namespace Lgym.Services.Enums
{
    public enum BodyPart
    {
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Chest), typeof(Resources.Resources.Enum))]
        Chest,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Back), typeof(Resources.Resources.Enum))]
        Back,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Shoulders), typeof(Resources.Resources.Enum))]
        Shoulders,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Biceps), typeof(Resources.Resources.Enum))]
        Biceps,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Triceps), typeof(Resources.Resources.Enum))]
        Triceps,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Forearms), typeof(Resources.Resources.Enum))]
        Forearms,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Abs), typeof(Resources.Resources.Enum))]
        Abs,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Quads), typeof(Resources.Resources.Enum))]
        Quads,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Hamstrings), typeof(Resources.Resources.Enum))]
        Hamstrings,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Calves), typeof(Resources.Resources.Enum))]
        Calves,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Glutes), typeof(Resources.Resources.Enum))]
        Glutes,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Traps), typeof(Resources.Resources.Enum))]
        Traps,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Lats), typeof(Resources.Resources.Enum))]
        Lats,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Neck), typeof(Resources.Resources.Enum))]
        Neck,
        [LocalizedDescription(nameof(Resources.Resources.Enum.BodyPart_Legs), typeof(Resources.Resources.Enum))]
        Legs
    }
}

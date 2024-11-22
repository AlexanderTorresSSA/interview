using Epic.Business.Rules.Pattern.Contract;
using Epic.CrossCutting.DTOs.Enums;
using Epic.CrossCutting.DTOs.Models;

namespace Epic.Business.Rules.Pattern;

public class CanProvideCiGreenlightState : IGreenlightActionState
{
    public void Execute(GreenlightCommsModel model, List<string> updatedProperties)
    {
        updatedProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightStatusDate));
        updatedProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightStatusId));
        model.CongressionalNotificationGreenlightStatusDate = DateTime.Now;
        model.CongressionalNotificationGreenlightStatusId = (int)GreenlightStatus.CongressionalNotificationGreenLightProvided;
    }
}
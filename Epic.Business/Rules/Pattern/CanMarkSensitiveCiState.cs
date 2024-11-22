using Epic.Business.Rules.Pattern.Contract;
using Epic.CrossCutting.DTOs.Enums;
using Epic.CrossCutting.DTOs.Models;

namespace Epic.Business.Rules.Pattern;

public class CanMarkSensitiveCiState : IGreenlightActionState
{
    public void Execute(GreenlightCommsModel model, List<string> updatedProperties)
    {
        updatedProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightStatusDate));
        updatedProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightStatusId));
        updatedProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightOnHoldJustification));
        model.CongressionalNotificationGreenlightStatusDate = DateTime.Now;
        model.CongressionalNotificationGreenlightStatusId = (int)GreenlightStatus.CongressionalNotificationGreenLightOnHold;
    }
}
using Epic.Business.Rules.Pattern.Contract;
using Epic.CrossCutting.DTOs.Models;

namespace Epic.Business.Rules.Pattern;

public class CanStartCiSensitiveCheckState : IGreenlightActionState
{
    public void Execute(GreenlightCommsModel model, List<string> updatedProperties)
    {
        updatedProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightSensitivityStartDate));
        model.CongressionalNotificationGreenlightSensitivityStartDate = DateTime.Now;
    }

   
}
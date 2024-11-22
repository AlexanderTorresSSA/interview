using Epic.Business.Rules.Pattern.Contract;
using Epic.CrossCutting.DTOs.Enums;
using Epic.CrossCutting.DTOs.Models;

namespace Epic.Business.Rules.Pattern;

public class CanProvidePubGreenlightState : IGreenlightActionState
{
    public void Execute(GreenlightCommsModel model, List<string> updatedProperties)
    {
        updatedProperties.Add(nameof(GreenlightCommsModel.PublicationGreenlightStatusDate));
        updatedProperties.Add(nameof(GreenlightCommsModel.PublicationGreenlightStatusId));
        model.PublicationGreenlightStatusDate = DateTime.Now;
        model.PublicationGreenlightStatusId = (int)GreenlightStatus.PublicationGreenLightProvided;
    }
}
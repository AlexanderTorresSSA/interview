using Epic.CrossCutting.DTOs.Models;

namespace Epic.Business.Rules.Pattern.Contract;

public interface IGreenlightActionState
{
    void Execute(GreenlightCommsModel model, List<string> updatedProperties);
}
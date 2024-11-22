using Epic.CrossCutting.DTOs.Models;

namespace Epic.Business.Rules.Announcement.AnnouncementDevelopment;

public interface IGreenlightCommissionsRuleService
{
    /// <summary>
    /// Executes the greenlight commissions rule logic on the provided model.
    /// </summary>
    /// <param name="model">The <see cref="GreenlightCommsModel"/> to process.</param>
    /// <returns>An <see cref="IRuleServiceOutput{T}"/> containing the processed model and a list of modified properties.</returns>
    IRuleServiceOutput<GreenlightCommsModel> Execute(GreenlightCommsModel model);
}
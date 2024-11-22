using Epic.Business.Rules.Pattern;
using Epic.Business.Rules.Pattern.Contract;
using Epic.CrossCutting.DTOs.Enums;
using Epic.CrossCutting.DTOs.Models;

namespace Epic.Business.Rules.Announcement.AnnouncementDevelopment;

public class GreenlightCommissionsRuleService : IGreenlightCommissionsRuleService
{
    private readonly Dictionary<GreenLightAction, IGreenlightActionState> _states;

    public GreenlightCommissionsRuleService()
    {
        // Initialize state mapping
        _states = new Dictionary<GreenLightAction, IGreenlightActionState>
        {
            { GreenLightAction.CanStartCiSensitiveCheck, new CanStartCiSensitiveCheckState() },
            { GreenLightAction.CanProvideCiGreenlight, new CanProvideCiGreenlightState() },
            { GreenLightAction.CanStartPubSensitiveCheck, new CanStartPubSensitiveCheckState() },
            { GreenLightAction.CanProvidePubGreenlight, new CanProvidePubGreenlightState() },
            { GreenLightAction.CanMarkSensitiveCi, new CanMarkSensitiveCiState() },
            { GreenLightAction.CanMarkSensitivePub, new CanMarkSensitivePubState() }
        };
    }

    public IRuleServiceOutput<GreenlightCommsModel> Execute(GreenlightCommsModel model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));

        var updatedProperties = new List<string>();

        // Find and execute the appropriate state
        if (_states.TryGetValue(model.CurrentGreenLightAction, out var state))
        {
            state.Execute(model, updatedProperties);
        }
        else
        {
            throw new InvalidOperationException($"Unsupported action: {model.CurrentGreenLightAction}");
        }

        return new RuleServiceOutput<GreenlightCommsModel>(model, updatedProperties);
    }
}
using Epic.CrossCutting.DTOs.Enums;
using Epic.CrossCutting.DTOs.Models;

namespace Epic.Business.Rules.Announcement.AnnouncementDevelopment;

//Summary
// The class below inherits from the IGreenlightCommissionsRuleService interface contract and implements
// an method called Execute that returns an object of type IRuleServiceOutput<GreenlightCommsModel>.

// The method Execute method accepts an input of type GreenlightCommsModel using variable model.

public class GreenlightCommissionsRuleService : IGreenlightCommissionsRuleService
    {
       
        public IRuleServiceOutput<GreenlightCommsModel> Execute(GreenlightCommsModel model)
        {
            var announcementProperties = new List<string>();

            if (model.CurrentGreenLightAction == GreenLightAction.CanStartCiSensitiveCheck)
            {
                announcementProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightSensitivityStartDate));
                model.CongressionalNotificationGreenlightSensitivityStartDate = DateTime.Now;
            }
            else if (model.CurrentGreenLightAction == GreenLightAction.CanProvideCiGreenlight)
            {
                announcementProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightStatusDate));
                announcementProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightStatusId));

                model.CongressionalNotificationGreenlightStatusDate = DateTime.Now;
                model.CongressionalNotificationGreenlightStatusId = (int)GreenlightStatus.CongressionalNotificationGreenLightProvided;
            }
            else if (model.CurrentGreenLightAction == GreenLightAction.CanStartPubSensitiveCheck)
            {
                announcementProperties.Add(nameof(GreenlightCommsModel.PublicationGreenlightSensitivityStartDate));
                model.PublicationGreenlightSensitivityStartDate = DateTime.Now;
            }
            else if (model.CurrentGreenLightAction == GreenLightAction.CanProvidePubGreenlight)
            {
                announcementProperties.Add(nameof(GreenlightCommsModel.PublicationGreenlightStatusDate));
                announcementProperties.Add(nameof(GreenlightCommsModel.PublicationGreenlightStatusId));

                model.PublicationGreenlightStatusDate = DateTime.Now;
                model.PublicationGreenlightStatusId = (int)GreenlightStatus.PublicationGreenLightProvided;
            }
            else if (model.CurrentGreenLightAction == GreenLightAction.CanMarkSensitiveCi)
            {
                announcementProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightStatusDate));
                announcementProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightStatusId));
                announcementProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightOnHoldJustification));

                model.CongressionalNotificationGreenlightStatusDate = DateTime.Now;
                model.CongressionalNotificationGreenlightStatusId = (int)GreenlightStatus.CongressionalNotificationGreenLightOnHold;
            }
            else if (model.CurrentGreenLightAction == GreenLightAction.CanMarkSensitivePub)
            {
                announcementProperties.Add(nameof(GreenlightCommsModel.PublicationGreenlightStatusDate));
                announcementProperties.Add(nameof(GreenlightCommsModel.PublicationGreenlightStatusId));
                announcementProperties.Add(nameof(GreenlightCommsModel.PublicationGreenlightOnHoldJustification));

                model.PublicationGreenlightStatusDate = DateTime.Now;
                model.PublicationGreenlightStatusId = (int)GreenlightStatus.PublicationGreenLightOnHold;
            }

            return new RuleServiceOutput<GreenlightCommsModel>(model, announcementProperties);
        }
    }







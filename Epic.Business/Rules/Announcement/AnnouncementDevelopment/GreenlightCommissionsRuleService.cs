using Epic.CrossCutting.DTOs.Enums;
using Epic.CrossCutting.DTOs.Models;

namespace Epic.Business.Rules.Announcement.AnnouncementDevelopment;

// This service class implements an interface contract called IGreenlightCommissionsRuleService
// The contract defines a method called Execute that takes a GreenlightCommsModel as input and returns an IRuleServiceOutput<GreenlightCommsModel>
public class GreenlightCommissionsRuleService : IGreenlightCommissionsRuleService
    {
       // Execution method accepts an input model of type GreenlightCommsModel and returns an IRuleServiceOutput<GreenlightCommsModel>
        public IRuleServiceOutput<GreenlightCommsModel> Execute(GreenlightCommsModel model)
        {
            // Create a list of strings to store the names of the properties that were modified
            var announcementProperties = new List<string>();

            // Check the CurrentGreenLightAction property of the input model and perform the appropriate action
            if (model.CurrentGreenLightAction == GreenLightAction.CanStartCiSensitiveCheck)
            {
                // if condition above is true, add the property names to the list of modified properties
                announcementProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightSensitivityStartDate));
                model.CongressionalNotificationGreenlightSensitivityStartDate = DateTime.Now;
            }
            // Check the CurrentGreenLightAction property of the input model and perform the appropriate action
            else if (model.CurrentGreenLightAction == GreenLightAction.CanProvideCiGreenlight)
            {
                // if condition above is true, add the announcement properties to the list of modified properties
                announcementProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightStatusDate));
                announcementProperties.Add(nameof(GreenlightCommsModel.CongressionalNotificationGreenlightStatusId));
                // Set the properties of the input model to the current date and the appropriate status
                model.CongressionalNotificationGreenlightStatusDate = DateTime.Now;
                model.CongressionalNotificationGreenlightStatusId = (int)GreenlightStatus.CongressionalNotificationGreenLightProvided;
            }
            // Does another check on the CurrentGreenLightAction enum property of the input model, checking if it is equal to the CanStartPubSensitiveCheck enum value
            else if (model.CurrentGreenLightAction == GreenLightAction.CanStartPubSensitiveCheck)
            {
                // if condition above is true, add the announcement properties to the list of modified properties
                announcementProperties.Add(nameof(GreenlightCommsModel.PublicationGreenlightSensitivityStartDate));
                // Set the property of the input model to the current date
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
            // Returns a new instance of the RuleServiceOutput class that implements the IRuleServiceOutput interface
            // The class has a constructor that takes a GreenlightCommsModel and a list of modified properties as input
            // These values are used to initialize the properties of the class and data is returned to the caller. 
            return new RuleServiceOutput<GreenlightCommsModel>(model, announcementProperties);
        }
    }







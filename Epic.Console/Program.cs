// See https://aka.ms/new-console-template for more information

using Epic.Business.Rules;
using Epic.Business.Rules.Announcement.AnnouncementDevelopment;
using Epic.CrossCutting.DTOs.Enums;
using Epic.CrossCutting.DTOs.Models;

var service = new GreenlightCommissionsRuleService();

// Prepare the model with a specific action
var model = new GreenlightCommsModel
{
    CurrentGreenLightAction = GreenLightAction.CanProvideCiGreenlight,
    CongressionalNotificationGreenlightStatusDate = DateTime.Now.AddDays(-1),
    CongressionalNotificationGreenlightStatusId = (int)GreenlightStatus.CongressionalNotificationGreenLightOnHold,
    CongressionalNotificationGreenlightOnHoldJustification = "Just Because!",
    PublicationGreenlightStatusDate = DateTime.Now.AddDays(-5),
    PublicationGreenlightStatusId = (int)GreenlightStatus.PublicationGreenLightProvided,
    PublicationGreenlightOnHoldJustification = "No congressional notification provided!",
    CongressionalNotificationGreenlightSensitivityStartDate = DateTime.Now.AddDays(-7),
    PublicationGreenlightSensitivityStartDate = DateTime.Now.AddDays(-4)
};

// Execute the service
IRuleServiceOutput<GreenlightCommsModel> result = service.Execute(model);

// Output the results
Console.WriteLine("Modified Properties:");
foreach (var property in result.ModifiedProperties)
{
    Console.WriteLine($"- {property}");
}

Console.WriteLine("\nUpdated Model Properties:");
if (result.Model.CongressionalNotificationGreenlightSensitivityStartDate.HasValue)
    Console.WriteLine($"CongressionalNotificationGreenlightSensitivityStartDate: {result.Model.CongressionalNotificationGreenlightSensitivityStartDate}");

if (result.Model.CongressionalNotificationGreenlightStatusDate.HasValue)
    Console.WriteLine($"CongressionalNotificationGreenlightStatusDate: {result.Model.CongressionalNotificationGreenlightStatusDate}");

Console.WriteLine($"CongressionalNotificationGreenlightStatusId: {result.Model.CongressionalNotificationGreenlightStatusId}");

if (!string.IsNullOrEmpty(result.Model.CongressionalNotificationGreenlightOnHoldJustification))
    Console.WriteLine($"CongressionalNotificationGreenlightOnHoldJustification: {result.Model.CongressionalNotificationGreenlightOnHoldJustification}");

// Wait for user input before closing
Console.WriteLine("\nPress any key to exit.");
Console.ReadKey();
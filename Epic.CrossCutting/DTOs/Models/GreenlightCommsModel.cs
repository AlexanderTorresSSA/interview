using Epic.CrossCutting.DTOs.Enums;

namespace Epic.CrossCutting.DTOs.Models;

public class GreenlightCommsModel
{
    // Current action being performed
    // Enum
    public GreenLightAction CurrentGreenLightAction { get; set; }

    // Congressional Notification properties
    public DateTime? CongressionalNotificationGreenlightSensitivityStartDate { get; set; }
    public DateTime? CongressionalNotificationGreenlightStatusDate { get; set; }
    public int CongressionalNotificationGreenlightStatusId { get; set; }
    public string? CongressionalNotificationGreenlightOnHoldJustification { get; set; }

    // Publication Greenlight properties
    public DateTime? PublicationGreenlightSensitivityStartDate { get; set; }
    public DateTime? PublicationGreenlightStatusDate { get; set; }
    public int PublicationGreenlightStatusId { get; set; }
    public string PublicationGreenlightOnHoldJustification { get; set; } = "N/A";
}
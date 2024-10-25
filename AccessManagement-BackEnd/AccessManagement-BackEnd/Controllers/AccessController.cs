using AccessManagement_BackEnd.Classes;
using Microsoft.AspNetCore.Mvc;


namespace AccessManagement_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessController : ControllerBase
    {
        private readonly ILogger<AccessController> _logger;

        public AccessController(ILogger<AccessController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "TryAccess")]
        public IActionResult TryAccess(User user, AccessPoint accessPoint)
        {
            try
            {
                if (user == null)
                {
                    _logger.LogWarning("User object is null.");
                    return BadRequest("User information is required.");
                }

                if (accessPoint == null)
                {
                    _logger.LogWarning("AccessPoint object is null.");
                    return BadRequest("Access point information is required.");
                }

                if (user.ProfileId == Guid.Empty)
                {
                    _logger.LogWarning("User profile is null for user: {UserId}", user.Id);
                    return BadRequest("User profile is missing.");
                }

                if (user.Profile.Permissions == null)
                {
                    _logger.LogWarning("Permissions list is null for profile: {ProfileId}", user.Profile.Id);
                    return BadRequest("Permissions are missing in user profile.");
                }

                bool hasPermission = user.Profile.Permissions.Any(p => p.Id == accessPoint.Id);
                if (!hasPermission)
                {
                    _logger.LogInformation("User {UserId} does not have permission to access {AccessPointId}.", user.Id, accessPoint.Id);
                    return Forbid("User does not have permission to access this point.");
                }

                // Log access attempt
                AccessRecord accessRecord = new AccessRecord(Guid.NewGuid(), user.Id, accessPoint.Id, DateTime.Now);
                _logger.LogInformation("Access granted for user {UserId} to access point {AccessPointId} at {AccessTime}.", user.Id, accessPoint.Id, DateTime.Now);

                return Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred during access verification.");
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}

using BaseLibrary.DTOs;

namespace Client.ApplicationState
{
    public class UserProfileState
    {
        public Action? Action { get; set; }
        public UserProfile userProfile { get; set; } = new();

      // We call this Invoke for as soon as the user upload the image before it reloud the page 
      // We want to see the image that we just upload 
        public void ProfileUpdated() => Action!.Invoke();
    }
}

namespace Upcoursework.Services.Settings.Settings;

public class SwaggerSettings
{
    public bool Enabled { get; private set; } = true;

    //public string OAuthClientId { get; private set; }
    //public string OAuthClientSecret { get; private set; }

    public SwaggerSettings()
    {
        Enabled = true;
    }
}

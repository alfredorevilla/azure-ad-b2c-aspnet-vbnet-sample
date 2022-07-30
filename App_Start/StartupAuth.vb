Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.IdentityModel.Protocols.OpenIdConnect
Imports Microsoft.IdentityModel.Tokens
Imports Microsoft.Owin.Extensions
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.OpenIdConnect
Imports Owin

Partial Public Class Startup
    Private Shared clientId As String = ConfigurationManager.AppSettings("ida:ClientId")
    Private Shared redirectUri As String = ConfigurationManager.AppSettings("ida:RedirectUri")
    Public Shared metadataAddress As String = ConfigurationManager.AppSettings("ida:MetadataAddress")

    Public Sub ConfigureAuth(app As IAppBuilder)
        app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType)

        app.UseCookieAuthentication(New CookieAuthenticationOptions())

        app.UseOpenIdConnectAuthentication(CreateOptions())

        app.UseStageMarker(PipelineStage.Authenticate)
    End Sub

    Private Function CreateOptions() As OpenIdConnectAuthenticationOptions
        Dim options = New OpenIdConnectAuthenticationOptions With {
            .MetadataAddress = metadataAddress,
            .RedirectUri = redirectUri,
            .PostLogoutRedirectUri = redirectUri,
            .ClientId = clientId,
            .Scope = "openid",
            .ResponseType = "id_token"
        }
        Return options
    End Function


    Private Shared Function EnsureTrailingSlash(ByRef value As String) As String
        If (IsNothing(value)) Then
            value = String.Empty
        End If

        If (Not value.EndsWith("/", StringComparison.Ordinal)) Then
            Return value & "/"
        End If

        Return value
    End Function
End Class
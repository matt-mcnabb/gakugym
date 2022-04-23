namespace GakuGym.Server;

using GakuGym.Common;

internal partial class Endpoints
{
    private readonly IGakuGymAPI GakuGymAPI;
    private readonly Security    Security;

    public Endpoints(IGakuGymAPI gakuGymAPI, Security security)
    {
        GakuGymAPI = gakuGymAPI;
        Security   = security;    
    }
}

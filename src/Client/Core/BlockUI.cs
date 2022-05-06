namespace GakuGym.Client;

using Microsoft.JSInterop;

internal class BlockUI
{
    private IJSRuntime jsRuntime;
    
    public BlockUI(IJSRuntime jSRuntime)
    {
        this.jsRuntime = jSRuntime;
    }

    public async Task Block()
    {
        await jsRuntime.InvokeVoidAsync("interop.blockUI");
    }

    public async Task Unblock()
    {
        await jsRuntime.InvokeVoidAsync("interop.unblockUI");
    }
}

window.interop =
{
    blockUI: function()
    {
        $.blockUI
        ({
            message: '',
            fadeIn:1000
        });
    },

    unblockUI: function()
    {
        $.unblockUI();
    }
};
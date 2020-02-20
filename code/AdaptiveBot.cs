using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Adaptive;
using Microsoft.Bot.Builder.Dialogs.Debugging;
using Microsoft.Bot.Builder.Dialogs.Declarative;
using Microsoft.Bot.Builder.Dialogs.Declarative.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace adaptive_dialogs_3
{
    public class AdaptiveBot : ActivityHandler
    {
        private ResourceExplorer resourceExplorer;
        private DialogManager dialogManager;

        public AdaptiveBot(ResourceExplorer resourceExplorer)
        {
            this.resourceExplorer = resourceExplorer;

            void LoadRootDialog()
            {
                // user scoped
                //var root = this.resourceExplorer.GetResource("userScoped.dialog");
                //this.dialogManager = new DialogManager(DeclarativeTypeLoader.Load<AdaptiveDialog>(root, resourceExplorer, DebugSupport.SourceMap));

                // conversation scoped
                //var root = this.resourceExplorer.GetResource("conversationScoped.dialog");
                //this.dialogManager = new DialogManager(DeclarativeTypeLoader.Load<AdaptiveDialog>(root, resourceExplorer, DebugSupport.SourceMap));

                // dialog scoped
                //var child = this.resourceExplorer.GetResource("dialogScoped-child.dialog");
                //DeclarativeTypeLoader.Load<AdaptiveDialog>(child, resourceExplorer, DebugSupport.SourceMap);
                //var root = this.resourceExplorer.GetResource("dialogScoped-parent.dialog");
                //this.dialogManager = new DialogManager(DeclarativeTypeLoader.Load<AdaptiveDialog>(root, resourceExplorer, DebugSupport.SourceMap));

                // turn scoped
                var root = this.resourceExplorer.GetResource("turnScoped.dialog");
                this.dialogManager = new DialogManager(DeclarativeTypeLoader.Load<AdaptiveDialog>(root, resourceExplorer, DebugSupport.SourceMap));
            }

            LoadRootDialog();
        }

        public async override Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            await dialogManager.OnTurnAsync(turnContext, cancellationToken);
        }
    }
}

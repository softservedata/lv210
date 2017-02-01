using System;
using ArtOfTest.Common.Win32;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Win32.Dialogs;

namespace Wow.Helpers
{
    public class Dialog : BaseDialog
    {
        #region Members

        /// <summary>
        /// The desktop object used to click dialog buttons.
        /// </summary>
        private Desktop desktopObject;

        #endregion

        #region Private Constants

        /// <summary>
        /// The title (caption) of the dialog we want handled.
        /// </summary>
        private readonly string dialogTitle;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Dialog class.
        /// Create the dialog handler instance by passing it the parent browser and the
        /// button to click on to dismiss the dialog.
        /// </summary>
        /// <param name="parentBrowser">The parent browser.</param>
        /// <param name="dismissButton">The button to click to dismiss the dialog.</param>
        /// <param name="desktop">The desktop object to use for Mouse.Click calls.</param>
        /// <param name="title">Dialog title.</param>
        public Dialog(Browser parentBrowser, DialogButton dismissButton, Desktop desktop, string title)
            : base(parentBrowser, dismissButton)
        {
            if (dismissButton != DialogButton.YES && dismissButton != DialogButton.NO
                && dismissButton != DialogButton.CLOSE && dismissButton != DialogButton.OK)
            {
                throw new ArgumentException("Security dialog can only have dismiss button of types : YES, NO or CLOSE.");
            }
            this.desktopObject = desktop;
            this.dialogTitle = title;
        }

        #endregion

        #region Base Dialog Implementation

        /// <summary>
        /// Check whether the dialog is present or not. This function is
        /// called by the dialogmonitor object.
        /// </summary>
        /// <param name="dialogs">This is a list of dialogs passed in
        /// by the DialogMonitor.</param>
        /// <returns>True/False whether this dialog is present.</returns>
        public override bool IsDialogActive(ArtOfTest.Common.Win32.WindowCollection dialogs)
        {
            return this.IsDialogActiveByTitle(dialogs, this.dialogTitle);
        }

        /// <summary>
        /// This is called by the DialogMonitor whenever IsDialogActive returns true.
        /// </summary>>
        public override void Handle()
        {
            // If you are sharing this implementation with other
            // developers, this allows them to override this method
            // by setting the handler delegate. So if the
            // delegate is null, perform the built in handling logic
            // otherwise call the custom handling logic.
            if (this.HandlerDelegate != null)
            {
                this.HandlerDelegate(this);
            }
            else
            {
                try
                {
                    Window yesButton = WindowManager.FindWindowRecursively(this.Window.Handle, "&Yes", false, 0);
                    Window noButton = WindowManager.FindWindowRecursively(this.Window.Handle, "&No", false, 0);
                    Window okButton = WindowManager.FindWindowRecursively(this.Window.Handle, "OK", false, 0);

                    switch (this.DismissButton)
                    {
                        case DialogButton.CLOSE:
                            this.Window.Close();
                            break;

                        case DialogButton.OK:
                            this.desktopObject.Mouse.Click(MouseClickType.LeftClick, okButton.Rectangle);
                            break;

                        case DialogButton.YES:
                            this.desktopObject.Mouse.Click(MouseClickType.LeftClick, yesButton.Rectangle);
                            break;

                        case DialogButton.NO:
                            this.desktopObject.Mouse.Click(MouseClickType.LeftClick, noButton.Rectangle);
                            break;
                    }

                    // Make sure the dialog is knocked down.
                    this.Window.WaitForVisibility(false, 500);
                }
                catch
                {
                    // Do any custom handling and return error.
                }
            }
        }

        #endregion
    }
}
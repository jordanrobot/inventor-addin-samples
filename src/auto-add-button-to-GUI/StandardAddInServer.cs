using Inventor;
using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoAddToGui
{
    /// <summary>
    /// This is the primary AddIn Server class that implements the ApplicationAddInServer interface
    /// that all Inventor AddIns are required to implement. The communication between Inventor and
    /// the AddIn is via the methods on this interface.
    /// </summary>
    [ProgId("auto-add-to-gui.StandardAddinServer")]
[GuidAttribute("F90B26F4-4CFF-472E-91B8-725DB2245785")]
public class StandardAddInServer : Inventor.ApplicationAddInServer
{

    // Inventor application object.
    private Inventor.Application m_inventorApplication;

    //Create the button definition, we create it here so that it is in scope for Activate and Deactivate
    // methods within this class
    private Inventor.ButtonDefinition testButtonDefinition;


    public StandardAddInServer()
    {
    }

    #region ApplicationAddInServer Members

    public void Activate(Inventor.ApplicationAddInSite addInSiteObject, bool firstTime)
    {
        m_inventorApplication = addInSiteObject.Application;

        ControlDefinitions controlDefs = m_inventorApplication.CommandManager.ControlDefinitions;
        stdole.IPictureDisp smallPicture = PictureConverter.ImageToPictureDisp(Properties.Resources.TestRibbonIcon16x16);
        stdole.IPictureDisp largePicture = PictureConverter.ImageToPictureDisp(Properties.Resources.TestRibbonIcon32x32);

        //  create a simple button to trigger our wpf window...
        var commandManager = m_inventorApplication.CommandManager;
        testButtonDefinition = commandManager.ControlDefinitions.AddButtonDefinition("Sample Command",
                                                                                     "SampleCommand",
                                                                                     CommandTypesEnum.kQueryOnlyCmdType,
                                                                                     "F90B26F4-4CFF-472E-91B8-725DB2245785",
                                                                                     "",
                                                                                     "",
                                                                                     smallPicture,
                                                                                     largePicture);

        // define a button handler...
        testButtonDefinition.OnExecute += testButtonDefinition_OnExecute;
        testButtonDefinition.AutoAddToGUI();
    }

    private void testButtonDefinition_OnExecute(NameValueMap Context)
    {
        ExecuteCommand();
    }

    private void ExecuteCommand()
    {
        throw new NotImplementedException("This command has not been created yet.");
    }

    public void Deactivate()
    {
        // This method is called by Inventor when the AddIn is unloaded.
        // The AddIn will be unloaded either manually by the user or
        // when the Inventor session is terminated

        // TODO: Add ApplicationAddInServer.Deactivate implementation

        // Release objects.
        testButtonDefinition.OnExecute -= testButtonDefinition_OnExecute;
        testButtonDefinition = null;
        m_inventorApplication = null;

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    public void ExecuteCommand(int commandID)
    {
        // Note:this method is now obsolete, you should use the
        // ControlDefinition functionality for implementing commands.
    }

    public object Automation
    {
        // This property is provided to allow the AddIn to expose an API
        // of its own to other programs. Typically, this  would be done by
        // implementing the AddIn's API interface in a class and returning
        // that class object through this property.

        get
        {
            // TODO: Add ApplicationAddInServer.Automation getter implementation
            return null;
        }
    }

    #endregion

}
}

# 手动资源设置指南

本指南提供分步说明，用于手动预配和配置在动手实验指南之前使用的 ARM 模板创建的资源。

> **IMPORTANT**: 重要提示：许多 Azure 资源需要全局唯一名称。在整个步骤中，"SUFFIX"一词显示为资源名称的一部分。应将其替换为 Microsoft 别名、首字母缩写或其他值，以确保资源唯一命名。

June 2020

**Contents**:

- [手动资源设置指南](#手动资源设置指南)
  - [任务 1: 创建 Azure 存储帐户](#任务-1-创建-azure-存储帐户)
  - [步骤 2: 创建 LabVM](#步骤-2-创建-labvm)
  - [任务 3：创建 SQL Server 2008 R2 虚拟机](#任务-3创建-sql-server-2008-r2-虚拟机)
  - [步骤 4: 预配 Azure SQL 数据库](#步骤-4-预配-azure-sql-数据库)
  - [任务 5：创建 Azure 数据库迁移服务](#任务-5创建-azure-数据库迁移服务)
  - [任务 6：预配 Web 应用](#任务-6预配-web-应用)
  - [任务 7：预配 API 应用](#任务-7预配-api-应用)
  - [任务 8：预配函数应用](#任务-8预配函数应用)
  - [任务 9：预配 API 管理](#任务-9预配-api-管理)
  - [任务 10：创建 Azure 认知搜索服务](#任务-10创建-azure-认知搜索服务)
  - [任务 11：创建认知服务帐户](#任务-11创建认知服务帐户)
  - [任务 12：创建 Azure 密钥保管库](#任务-12创建-azure-密钥保管库)
  - [任务 13：连接到Lab VM](#任务-13连接到lab-vm)
  - [任务 14：在 LabVM 上安装所需的软件](#任务-14在-labvm-上安装所需的软件)
  - [任务 15：连接到 SqlServer2008 VM](#任务-15连接到-sqlserver2008-vm)
  - [任务 16：在 SqlServer2008 VM 上还原和配置 Contoso 保险数据库](#任务-16在-sqlserver2008-vm-上还原和配置-contoso-保险数据库)
  - [任务 17：在 SqlServer2008 VM 上安装 Microsoft 数据迁移助手](#任务-17在-sqlserver2008-vm-上安装-microsoft-数据迁移助手)

## 任务 1: 创建 Azure 存储帐户

在此任务中，预配 Azure 存储帐户，该帐户用于存储策略文档，以及使用 SQL 高级数据安全执行的漏洞评估。

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "storage account" into the Search the Marketplace box, and select **Storage account** from the results, and then select **Create**.

   !["Storage account" is entered into the Search the Marketplace box. Storage account is selected in the results.](./media/create-resource-storage-account.png "Create Storage account")

3. On the Create storage account **Basics** tab, enter the following:

   - Project Details:

     - **Subscription**: Select the subscription you are using for this hands-on lab.
     - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

   - Instance Details:

     - **Storage account name**: Enter contosostoreSUFFIX.
     - **Location**: Select the location you are using for resources in this hands-on lab.
     - **Performance**: Choose **Standard**.
     - **Account kind**: Select **StorageV2 (general purpose v2)**.
     - **Replication**: Select **Locally-redundant storage (LRS)**.
     - **Access tier**: Choose **Hot**.

   ![On the Create storage account blade, the values specified above are entered into the appropriate fields.](media/storage-create-account.png "Create storage account")

4. Select **Review + create**.

5. On the **Review + create** blade, ensure the Validation passed message is displayed and then select **Create**.

## 步骤 2: 创建 LabVM

在此任务中，在 Azure 中预配虚拟机 （VM）。使用的 VM 映像安装了最新版本的 Visual Studio 2019 社区版。

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "visual studio 2019" into the Search the Marketplace box and then select **Visual Studio 2019 Latest** from the results.

   !["Visual studio 2019" is entered into the Search the Marketplace box. Visual Studio 2019 latest is selected in the results.](./media/create-resource-visual-studio-vm.png "Visual Studio 2019 Latest")

3. On the Visual Studio 2019 Latest blade, select **Visual Studio 2019 Community (latest release) on Windows Server 2019 (x64)** from the Select a software plan drop-down list, and then select **Create**.

   ![On the Visual Studio 2019 Latest blade, Visual Studio 2019 Community (latest release) on Windows Server 2019 (x64) is highlighted in the Select a software plan drop-down list.](media/visual-studio-create.png "Visual Studio 2019 Latest")

4. On the Create a virtual machine **Basics** tab set the following configuration:

   - Project Details:

     - **Subscription**: Select the subscription you are using for this hands-on lab.
     - **Resource Group**: Select the **hands-on-lab-SUFFIX** resource group from the list of existing resource groups.

   - Instance Details:

     - **Virtual machine name**: Enter LabVM.
     - **Region**: Select the region you are using for resources in this hands-on lab.
     - **Availability options**: Select no infrastructure redundancy required.
     - **Image**: Leave Visual Studio 2019 Community (latest release) on Windows Server 2019 (x64) selected.
     - **Azure Spot instance**: Select No.
     - **Size**: Accept the default size of Standard_D4s_v3.

   - Administrator Account:

     - **Username**: Enter **demouser**.
     - **Password**: Enter **Password.1!!**

   - Inbound Port Rules:

     - **Public inbound ports**: Choose Allow selected ports.
     - **Select inbound ports**: Select RDP (3389) in the list.

   ![Screenshot of the Basics tab, with fields set to the previously mentioned settings.](media/lab-virtual-machine-basics-tab.png "Create a virtual machine Basics tab")

   > **Note**: Default settings are used for the remaining tabs so that they can be skipped.

5. Select **Review + create** to validate the configuration.

6. On the **Review + create** tab, ensure the Validation passed message is displayed, and then select **Create** to provision the virtual machine.

   ![The Review + create tab is displayed, with a Validation passed message.](media/lab-virtual-machine-review-create-tab.png "Create a virtual machine Review + create tab")

7. It takes approximately 10 minutes for the VM to finish provisioning. You can move on to the next task while you wait.

## 任务 3：创建 SQL Server 2008 R2 虚拟机

在此任务中，预配另一个 Azure 虚拟机 （VM） 以托管 SQL Server 2008 R2 的"本地"实例。VM 在 Windows Server 2008 R2 映像上使用 SQL Server 2008 R2 SP3 标准。

> **Note**: 由于 Windows Server 2016 不支持 SQL Server 2008 R2，因此正在使用旧版本的 Windows 服务器。

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "SQL Server 2008 R2 SP3 on Windows Server 2008 R2" into the Search the Marketplace box.

3. On the **SQL Server 2008 R2 SP3 Standard on Windows Server 2008 R2** blade, select **SQL Server R2 SP3 Standard on Windows Server 2008 R2** for the software plan and then select **Create**.

   ![The SQL Server 2008 R2 SP3 on Windows Server 2008 R2 blade is displayed with the standard edition selected for the software plan, and the Create button highlighted.](media/create-resource-sql-server-2008-r2.png "Create SQL Server 2008 R2 Resource")

4. On the Create a virtual machine Basics tab set the following configuration:

   - Project Details:

     - **Subscription**: Select the subscription you are using for this hands-on lab.
     - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

   - Instance Details:

     - **Virtual machine name**: Enter SqlServer2008.
     - **Region**: Select the region you are using for resources in this hands-on lab.
     - **Availability options**: Select no infrastructure redundancy required.
     - **Image**: Leave SQL Server 2008 R2 SP3 Standard on Windows Server 2008 R2 selected.
     - **Azure Spot instance**: Select No.
     - **Size**: Accept the default size of Standard_D4s_v3.

   - Administrator Account:

     - **Username**: Enter **demouser**.
     - **Password**: Enter **Password.1!!**

   - Inbound Port Rules:

     - **Public inbound ports**: Choose Allow selected ports.
     - **Select inbound ports**: Select RDP (3389) in the list.

   ![Screenshot of the Basics tab, with fields set to the previously mentioned settings.](media/sql-server-2008-r2-vm-basics-tab.png "Create a virtual machine Basics tab")

5. Select the **SQL Server settings** tab from the top menu. Default values are used for Disks, Networking, Management, and Advanced tabs, so you don't need to do anything on those tabs.

   ![The SQL Server settings tab is highlighted and selected in the Create a virtual machine configuration tabs list.](media/sql-server-create-vm-sql-settings-tab.png "Create a virtual machine configuration tabs")

6. On the **SQL Server settings** tab, set the following properties:

   - Security & Networking:

     - **SQL connectivity**: Select Public (Internet).
     - **Port**: Leave set to 1433.

   - SQL Authentication:

     - **SQL Authentication**: Select Enable.
     - **Login name**: Enter demouser.
     - **Password**: Enter **Password.1!!**

   ![The previously specified values are entered into the SQL Server Settings blade.](media/sql-server-create-vm-sql-settings.png "SQL Server Settings")

7. Select **Review + create** to review the VM configuration.

8. On the **Review + create** tab, ensure the Validation passed message is displayed, and then select **Create** to provision the virtual machine.

   ![The Review + create tab is displayed, with a Validation passed message.](media/sql-server-2008-r2-vm-review-create-tab.png "Create a virtual machine Review + create tab")

9. It may take 10+ minutes for the virtual machine to complete provisioning. You can move on to the next task while waiting for the SqlServer2008 VM to provision.

## 步骤 4: 预配 Azure SQL 数据库

在此任务中，预配 Azure SQL 数据库 （Azure SQL DB）。

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "sql database" into the Search the Marketplace box, select **SQL Database** from the results, and then select **Create**.

   !["Sql database" is entered into the Search the Marketplace box. SQL Database is selected in the results.](media/create-resource-azure-sql-database.png "Create Azure SQL Database")

3. On the Create SQL Database **Basics** tab, enter the following:

   - Project Details:

     - **Subscription**: Select the subscription you are using for this hands-on lab.
     - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

   - Database Details:

     - **Database name**: Enter ContosoInsurance.
     - **Server**: Select **Create new**, and on the New server blade enter the following:
       - **Server name**: Enter contosoinsuranceSUFFIX.
       - **Server admin login**: Enter demouser.
       - **Password**: Enter Password.1!!
       - **Location**: Select the region you are using for resources in this hands-on lab.
       - Select **OK**.
     - **Want to use SQL elastic pool**: Choose No.
     - **Compute + storage**: Accept the default, General Purpose, Gen5, 2 vCores, 32 GB storage.

   ![The Create SQL Database Basics tab is displayed, with the values specified above entered into the appropriate fields.](media/create-sql-database-basics-tab.png "Create SQL Database")

4. Select **Next: Networking**.

5. On the **Networking** tab, set the following:

   - **Connectivity method**: Choose Public endpoint.
   - **Allow Azure services and resources to access this server**: Select Yes.
   - **Add current client IP address**: Select No. If you would like to be able to access the Azure SQL database directly from your workstation, you can choose Yes for this.

   ![On the Networking tab, the connectivity method is set to Public endpoint and Yes is selected for allowing Azure services and resources to access this server.](media/create-sql-database-networking-tab.png "Create SQL Database Networking")

6. Select **Next: Additional settings**.

7. On the **Additional settings** tab, **Enable Advanced Data Security** by selecting **Start free trial**.

   ![On the Additional settings tab, Enable Advanced Data Security is highlighted and Start free trial is selected.](media/create-sql-database-additional-settings-tab.png "Create SQL Database")

8. Select **Review + create**.

9. On the **Review + create** tab, select **Create** to provision the SQL Database.

## 任务 5：创建 Azure 数据库迁移服务

In this task, you provision an instance of the Azure Database Migration Service (DMS).

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "database migration" into the Search the Marketplace box, select **Azure Database Migration Service** from the results, and select **Create**.

   !["Database migration" is entered into the Search the Marketplace box. Azure Database Migration Service is selected in the results.](media/create-resource-azure-database-migration-service.png "Create Azure Database Migration Service")

3. On the Create Migration Service **Basics** tab, enter the following:

   > **Note**: If you see the message, `Your subscription doesn't have proper access to Microsoft.DataMigration`, refresh the browser window before proceeding. If the message persists, verify you successfully registered the resource provider, and then you can safely ignore this message.

   - Project Details:

     - **Subscription**: Select the subscription you are using for this hands-on lab.
     - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

   - Instance Details:

     - **Migration service Name**: Enter contoso-dms-SUFFIX.
     - **Location**: Select the location you are using for resources in this hands-on lab.
     - **Service mode**: Select Azure.
     - **Pricing tier**: Select Configure tier and then select Premium: 4 vCores and select Apply.

   ![The Create Migration Service blade is displayed, with the values specified above entered into the appropriate fields.](media/create-migration-service-basics-tab.png "Create Migration Service")

4. Select **Next: Networking**.

5. On the **Networking** tab, select the **hands-on-lab-SUFFIX-vnet/default** virtual network by checking the box next to it in the list of existing virtual networks. This places the DMS instance into the same VNet as your LabVM and SqlServer2008 virtual machines.

   ![The hands-on-lab-vnet/default virtual network in checked and selected in the list of existing virtual networks on the Networking tab.](media/create-migration-service-networking-tab.png "Create Migration Service")

6. Select **Review + create**.

7. Select **Create**.

8. It can take 15 minutes to deploy the Azure Data Migration Service. You can move on to the next task while you wait.

## 任务 6：预配 Web 应用

在此任务中，您将预配应用服务 （Web App），它为 Contoso 保险 Web 应用程序提供托管。

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "web app" into the Search the Marketplace box, select **Web App** from the results.

   !["Web app" is entered into the Search the Marketplace box. Web App is selected in the results.](media/create-resource-web-app.png "Create Web App")

3. On the Web App blade, select **Create**.

   ![On the Web App blade, the Create button is highlighted.](media/create-web-app.png "Create Web App")

4. On the Create Web App **Basics** tab, set the following configuration:

   - Project Details:

     - **Subscription**: Select the subscription you are using for this hands-on lab.
     - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

   - Instance Details:

     - **Name**: Enter contoso-web-SUFFIX.
     - **Publish**: Select Code.
     - **Runtime stack**: Select .NET Core 3.1 (LTS).
     - **Operating System**: Select Windows.
     - **Region**: Select the region you are using for resources in this hands-on lab.

   - App Service Plan:

     - **Plan**: Select **Create new** and enter **hands-on-lab-asp** for the name.
     - **Sku and size**: Accept the default value of Standard S1.

   ![The values specified above are entered into the appropriate fields in the Create Web App Basics tab.](media/create-web-app-basics-tab.png "Create Web App")

5. Select **Next: Monitoring**.

6. On the **Monitoring** tab, select **No** next to Enable Application Insights.

   ![No is selected next to Enable Application Insights on the Monitoring tab.](media/create-web-app-monitoring-tab.png "Create Web App")

7. Select **Review and create**.

8. On the **Review and create** tab, select **Create**.

9. It takes a few minutes for the Web App creation to complete. You can move on to the next task while you wait.

## 任务 7：预配 API 应用

In this task, you provision an App Service (API App), which provides hosting for the Contoso Insurance APIs.

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "api app" into the Search the Marketplace box, select **API App** from the results.

   !["Api app" is entered into the Search the Marketplace box. API App is selected in the results.](media/create-resource-api-app.png "Create API App")

3. On the API App blade, select **Create**.

4. On the API App Create blade, enter the following:

   - **App name**: Enter contoso-api-SUFFIX.
   - **Subscription**: Select the subscription you are using for this hands-on lab.
   - **Resource Group**: Choose Use exiting and select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.
   - **App Service plan/Location**: Select the hands-on-lab-asp App Service plan.
   - **Application Insights**: Select **Disabled**.

   ![On the API App Create blade, the values specified above are entered into the appropriate fields.](media/create-api-app-basics-tab.png "Create API App")

5. Select **Create**.

## 任务 8：预配函数应用

In this task, you provision a Function App, which is used for retrieving PDF documents from Azure Storage.

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "function app" into the Search the Marketplace box, select **Function App** from the results.

   !["Function app" is entered into the Search the Marketplace box. Function App is selected in the results.](media/create-resource-function-app.png "Create Web App")

3. On the Function App blade, select **Create**.

4. On the Function App Basics blade, enter the following:

   - Project Details:

     - **Subscription**: Select the subscription you are using for this hands-on lab.
     - **Resource Group**: Choose Use exiting and select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

   - Instance Details:

     - **Function App name**: Enter contoso-func-SUFFIX.
     - **Publish**: Select Code.
     - **Runtime Stack**: Select .NET Core.
     - **Version**: Accept the default version, which should be the latest.
     - **Region**: Select the region you are using for resources in this hands-on lab.

   ![On the Function App Basics tab, the values specified above are entered into the associated fields.](media/create-function-app-basics-tab.png "Create Function App")

5. Select **Next: Hosting**.

   - **Storage Account**: Select the storage account you created in Task 1, above.
   - **Operating System**: Select Windows.
   - **Plan type**: Select Consumption.

   ![On the Function App Hosting tab, the values specified above are entered into the fields.](media/create-function-app-hosting-tab.png "Create Function App")

6. Select **Next: Monitoring**.

   - **Enable Application Insights**: Select **No**.

   ![Enable Application Insights is set to no on the Monitoring tab.](media/create-function-app-monitoring-tab.png "Create Function App")

7. Select **Review + create**.

   ![A summary of the configured settings is displayed on the Review + create tab.](media/create-function-app-review-create-tab.png "Create Function App")

8. Select **Create**.

## 任务 9：预配 API 管理

In this task, you provision API Management (APIM). APIM provides the ability to manage the Contoso APIs.

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "api management" into the Search the Marketplace box, select **API Management** from the results.

   !["Api management" is entered into the Search the Marketplace box. API Management is selected in the results.](media/create-resource-api-management.png "Create Web App")

3. On the API Management blade, select **Create**.

4. On the API Management service blade, enter the following:

   - **Name**: Enter contoso-apim-SUFFIX.
   - **Subscription**: Select the subscription you are using for this hands-on lab.
   - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.
   - **Location**: Select the location you are using for resources in this hands-on lab.
   - **Organization name**: Enter Contoso Insurance.
   - **Administrator email**: Enter an email add that can receive API Management admin notifications.
   - **Pricing tier**: Select Developer (No SLA).
   - **Enable Application Insights**: Uncheck this box.

   ![The values specified above are entered into the API Management service blade.](media/api-management-service-create.png "Create API Management service")

5. Select **Create**.

6. It takes around 30 minutes for API Management to finish provisioning. You can move on to the next task while you wait.

## 任务 10：创建 Azure 认知搜索服务

In this task, you create an Azure Cognitive Search service.

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "Azure Cognitive Search" into the Search the Marketplace box.

3. On the Azure Cognitive Search blade, select **Create**.

4. On the New Search Service **Basics** tab, enter the following:

   - Project Details:

     - **Subscription**: Select the subscription you are using for this hands-on-lab.
     - **Resource group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

   - Instance Details:

     - **URL**: Enter contoso-search-SUFFIX.
     - **Location**: Select the region you are using for resources in this hands-on-lab.
     - **Pricing tier**: Accept the default, Standard.

   ![The values specified above are entered into the Basics tab for a New Search Service.](media/new-search-service-basics-tab.png "New Search Service")

5. Select **Review + create**.

6. Select **Create** to provision the new search service.

7. It takes around 10 minutes for the new search service to finish provisioning. You can move on to the next task while you wait.

## 任务 11：创建认知服务帐户

In this task, you create a Cognitive Services account.

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "cognitive services" into the Search the Marketplace box, select **Cognitive Services** from the results.

   !["Cognitive services" is entered into the Search the Marketplace box. Cognitive Services is selected in the results.](media/create-resource-cognitive-services.png "Create Cognitive Services account")

3. On the Cognitive Services blade, select **Create**.

4. On the Cognitive Services Create blade, enter the following:

   - **Name**: Enter contoso-cog-services.
   - **Subscription**: Select the subscription you are using for this hands-on lab.
   - **Location**: Select the region you are using for resources in this hands-on lab.
   - **Pricing tier**: Select Standard S0.
   - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.
   - Check the box to confirm you have read and understood the notice.

   ![The values specified above are entered into the Create blade.](media/cognitive-services-create.png "Create Cognitive Services")

5. Select **Create**.

## 任务 12：创建 Azure 密钥保管库

In this task, you provision an Azure Key Vault, which enables application secrets to be stored securely.

1. In the [Azure portal](https://portal.azure.com/), select the **Show portal menu** icon and then select **+Create a resource** from the menu.

   ![The Show portal menu icon is highlighted, and the portal menu is displayed. Create a resource is highlighted in the portal menu.](media/create-a-resource.png "Create a resource")

2. Enter "key vault" into the Search the Marketplace box, select **Key Vault** from the results.

   !["Key vault" is entered into the Search the Marketplace box. Key Vault is selected in the results.](media/create-resource-key-vault.png "Create Key Vault")

3. On the Key Vault blade, select **Create**.

4. On the Create Key Vault **Basics** tab, enter the following:

   - Project Details:

     - **Subscription**: Select the subscription you are using for this hands-on lab.
     - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

   - Instance Details:

     - **Key vault name**: Enter contoso-kv-SUFFIX.
     - **Region**: Select the region you are using for resources in this hands-on lab.
     - **Pricing tier**: Select Standard.
     - **Soft-delete**: Select Disable.
     - **Retention period (days)**: Leave the default value of 90.
     - **Purge protection**: Select Disable.

   ![The values specified above are entered into the Create Key Vault blade.](media/key-vault-create-basics-tab.png "Create Key Vault")

5. Select **Review + create**. The default values for Access policy and Virtual network are used so that these tabs can be skipped.

6. On the **Review + create** tab, select **Create**.

## 任务 13：连接到Lab VM

在此任务中，创建到实验室虚拟机 （VM） 的 RDP 连接，并禁用 Internet 资源管理器增强的安全配置。

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** from the Azure services list.

   ![Resource groups is highlighted in the Azure services list.](media/azure-services-resource-groups.png "Azure services")

2. Select the hands-on-lab-SUFFIX resource group from the list.

   ![The "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png "Resource groups list")

3. In the list of resources within your resource group, select the LabVM Virtual machine resource.

   ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and LabVM is highlighted.](./media/resource-group-resources-labvm.png "LabVM in resource group list")

4. On your LabVM blade, select **Connect** and **RDP** from the top menu.

   ![The LabVM blade is displayed, with the Connect button highlighted in the top menu.](./media/connect-vm-rdp.png "Connect to Lab VM")

5. On the Connect to virtual machine blade, select **Download RDP File**, then open the downloaded RDP file.

   ![The Connect to virtual machine blade is displayed, and the Download RDP File button is highlighted.](./media/connect-to-virtual-machine.png "Connect to virtual machine")

6. Select **Connect** on the Remote Desktop Connection dialog.

   ![In the Remote Desktop Connection Dialog Box, the Connect button is highlighted.](./media/remote-desktop-connection.png "Remote Desktop Connection dialog")

7. Enter the following credentials when prompted, and then select **OK**:

   - **User name**: demouser
   - **Password**: Password.1!!

   ![The credentials specified above are entered into the Enter your credentials dialog.](media/rdc-credentials.png "Enter your credentials")

8. Select **Yes** to connect, if prompted that the identity of the remote computer cannot be verified.

   ![In the Remote Desktop Connection dialog box, a warning states that the identity of the remote computer cannot be verified, and asks if you want to continue anyway. At the bottom, the Yes button is circled.](./media/remote-desktop-connection-identity-verification-labvm.png "Remote Desktop Connection dialog")

9. Once logged in, launch the **Server Manager**. This should start automatically, but you can access it via the Start menu if it does not.

10. Select **Local Server**, then select **On** next to **IE Enhanced Security Configuration**.

    ![Screenshot of the Server Manager. In the left pane, Local Server is selected. In the right, Properties (For LabVM) pane, the IE Enhanced Security Configuration, which is set to On, is highlighted.](./media/windows-server-manager-ie-enhanced-security-configuration.png "Server Manager")

11. In the Internet Explorer Enhanced Security Configuration dialog, select **Off** under both Administrators and Users, and then select **OK**.

    ![Screenshot of the Internet Explorer Enhanced Security Configuration dialog box, with Administrators set to Off.](./media/internet-explorer-enhanced-security-configuration-dialog.png "Internet Explorer Enhanced Security Configuration dialog box")

12. Close the Server Manager, but leave the connection to the LabVM open for the next task.

## 任务 14：在 LabVM 上安装所需的软件

In this task, you configure the LabVM with the required software and downloads. First, you download and install SQL Server Management Studio (SSMS). Next, you download and install .NET Core 2.2. You also download a copy of the Visual Studio starter solution and unzip it into a folder named `C:\MCW`.

1. First, install SSMS on the LabVM by opening a web browser on your LabVM and navigating to <https://aka.ms/ssmsfullsetup>. This link downloads the latest version of SSMS.

   > **Note**: Versions change frequently, so if the version number you see does not match the screenshot below, download and install the most recent version.

2. Run the downloaded installer.

3. On the Welcome screen, select **Install** to begin the installation.

   ![The Install button is highlighted on the SSMS installation welcome screen.](media/ssms-install.png "Install SSMS")

4. Select **Close** when the installation completes.

   ![The Close button is highlighted on the SSMS Setup Completed dialog.](media/ssms-install-close.png "Setup completed")

5. Next, [download the .NET Core 2.2 SDK](https://download.visualstudio.microsoft.com/download/pr/279de74e-f7e3-426b-94d8-7f31d32a129c/e83e8c4c49bcb720def67a5c8fe0d8df/dotnet-sdk-2.2.207-win-x64.exe).

6. Run the downloaded installer.

7. Next, [download a copy of the GitHub repo for the App modernization MCW](https://github.com/microsoft/MCW-App-modernization/archive/master.zip).

8. Extract the download ZIP file to `C:\MCW`.

   ![The Extract Compressed Folders dialog is displayed, with `C:\MCW` entered into the extraction location.](media/mcw-download-extract.png "Extract Compressed ZIP")

## 任务 15：连接到 SqlServer2008 VM

In this task, you open an RDP connection to the SqlServer2008 VM, disable Internet Explorer Enhanced Security Configuration, and add a firewall rule to open port 1433 to inbound TCP traffic.

> **Note**: There is a known issue with screen resolution when using an RDP connection to Windows Server 2008 R2, which may affect some users. This issue presents itself as very small, hard to read text on the screen. The workaround for this is to use a second monitor for the RDP display, which should allow you to scale up the resolution to make the text larger.

1. As you did for the LabVM, navigate to the SqlServer2008 VM blade in the Azure portal, select **Overview** from the left-hand menu, and then select **Connect** and **RDP** on the top menu.

   ![The SqlServer2008 VM blade is displayed, with the Connect button highlighted in the top menu.](./media/connect-vm-rdp.png "Connect to SqlServer2008 VM")

2. On the Connect to virtual machine blade, select **Download RDP File**, then open the downloaded RDP file.

3. Select **Connect** on the Remote Desktop Connection dialog.

   ![In the Remote Desktop Connection Dialog Box, the Connect button is highlighted.](./media/remote-desktop-connection-sql-2008.png "Remote Desktop Connection dialog")

4. Enter the following credentials when prompted, and then select **OK**:

   - **User name**: demouser
   - **Password**: Password.1!!

   ![The credentials specified above are entered into the Enter your credentials dialog.](media/rdc-credentials-sql-2008.png "Enter your credentials")

5. Select **Yes** to connect, if prompted that the identity of the remote computer cannot be verified.

   ![In the Remote Desktop Connection dialog box, a warning states that the identity of the remote computer cannot be verified, and asks if you want to continue anyway. At the bottom, the Yes button is circled.](./media/remote-desktop-connection-identity-verification-sqlserver2008.png "Remote Desktop Connection dialog")

6. Once logged in, launch the **Server Manager**. This should start automatically, but you can access it via the Start menu if it does not.

7. On the **Server Manager** view, select **Configure IE ESC** under Security Information.

   ![Screenshot of the Server Manager. In the left pane, Local Server is selected. In the right, Properties (For LabVM) pane, the IE Enhanced Security Configuration, which is set to On, is highlighted.](./media/windows-server-2008-manager-ie-enhanced-security-configuration.png "Server Manager")

8. In the Internet Explorer Enhanced Security Configuration dialog, select **Off** under both Administrators and Users, and then select **OK**.

   ![Screenshot of the Internet Explorer Enhanced Security Configuration dialog box, with Administrators set to Off.](./media/2008-internet-explorer-enhanced-security-configuration-dialog.png "Internet Explorer Enhanced Security Configuration dialog box")

## 任务 16：在 SqlServer2008 VM 上还原和配置 Contoso 保险数据库

In this task, you restore the `ContosoInsurance` database onto the SQL Server 2008 R2 instance using a backup provided by Contoso, Ltd.

1. On the SqlServer2008 VM, download a [backup of the ContosoInsurance database](https://raw.githubusercontent.com/microsoft/MCW-App-modernization/master/Hands-on%20lab/lab-files/Database/ContosoInsurance.zip), and extract the zipped files into `C:\ContosoInsurance` on the VM.

2. Next, open **Microsoft SQL Server Management Studio** (SSMS) by entering "sql server" into the search bar in the Windows Start menu and selecting **Microsoft SQL Server Management Studio 17** from the results.

   ![SQL Server is entered into the Windows Start menu search box, and Microsoft SQL Server Management Studio 17 is highlighted in the search results.](media/start-menu-ssms-17.png "Windows start menu search")

3. In the SSMS **Connect to Server** dialog, enter **SQLSERVER2008** into the Server name box, ensure **Windows Authentication** is selected, and then select **Connect**.

   ![The SQL Server Connect to Search dialog is displayed, with SQLSERVER2008 entered into the Server name and Windows Authentication selected.](media/sql-server-2008-connect-to-server.png "Connect to Server")

4. Once connected, right-click **Databases** under SQLSERVER2008 in the Object Explorer, and then select **Attach...** from the context menu.

   ![In the SSMS Object Explorer, the context menu for Databases is displayed and Restore Database is highlighted.](media/ssms-databases-attach.png "SSMS Object Explorer")

5. Now, attach the `ContosoInsurance` database using the downloaded `ContosoInsurance.mdf` and `ContosoInsurance_log.ldf` files. On the **General** page of the Attach Databases dialog, select the **Add** button, and in the Locate Database Files dialog, expand the ContosoInsurance folder, select `ContosoInsurance.mdf`, and then select **OK**.

   ![ContosoInsurance.mdf is selected and highlighted in the Select a file box. The OK button is highlighted.](media/ssms-attach-database-source.png "Locate Database files")

6. Back on the Attach Databases dialog, verify you see the ContosoInsurance Data and Log files under database details, and then select **OK**.

   ![The completed Attach Databases dialog is displayed, with the ContosoInsurance database specified as the target.](media/ssms-attach-database.png "Attach Database")

7. You should now see the `ContosoInsurance` database listed under Databases.

   ![The ContosoInsurance database is highlighted in the list of databases.](media/ssms-databases.png "Databases")

## 任务 17：在 SqlServer2008 VM 上安装 Microsoft 数据迁移助手

In this task, you install the Microsoft Data Migration Assistant (DMA) on the SqlServer2008 VM.

1. Install the Microsoft Data Migration Assistant v5.x by navigating to <https://www.microsoft.com/en-us/download/details.aspx?id=53595> in a web browser on the SqlServer2008 VM, and then select the **Download** button.

   ![The Download button is highlighted on the Data Migration Assistant download page.](media/dma-download.png "Download Data Migration Assistant")

   > **Note**: Versions change frequently, so if the version number you see does not match the screenshot, download and install the most recent version.

2. Run the downloaded installer.

3. Select **Next** on each of the screens, accepting the license terms and privacy policy in the process.

4. Select **Install** on the Privacy Policy screen to begin the installation.

5. On the final screen, select **Finish** to close the installer.

   ![The Finish button is selected on the Microsoft Data Migration Assistant Setup dialog.](./media/data-migration-assistant-setup-finish.png "Run the Microsoft Data Migration Assistant")

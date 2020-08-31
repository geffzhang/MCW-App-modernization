![Microsoft Cloud Workshops](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/master/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
应用现代化

</div>

<div class="MCWHeader2">
动手实验之前的设置指南
</div>

<div class="MCWHeader3">
June 2020
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2020 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

**Contents**

<!-- TOC -->

- [应用现代化动手实验之前的设置指南](#应用现代化动手实验之前的设置指南)
  - [Requirements](#requirements)
  - [动手实验前](#动手实验前)
    - [任务 1: 预配资源组](#任务-1-预配资源组)
    - [任务 2：注册所需的资源提供程序](#任务-2注册所需的资源提供程序)
    - [任务 3：运行 ARM 模板以预配实验室资源](#任务-3运行-arm-模板以预配实验室资源)

<!-- /TOC -->

# 应用现代化动手实验之前的设置指南

## Requirements

- Microsoft Azure 订阅必须是即用即付订阅或 MSDN
  - 用订阅将不起作用
- **IMPORTANT**: 重要提示：要完成本实验，Azure AD 租户中必须具有足够的权限，以：
  - 创建 Azure 活动目录应用程序和服务主体
  - 在订阅上分配角色
  - 注册资源提供程序

## 动手实验前

Duration: 45 分钟

在本练习中，您将设置一个环境，用于实践实验的其余部分。在参加动手实验之前，您应该按照提供的所有步骤操作。

> **IMPORTANT**: 许多 Azure 资源需要全局唯一名称。在这些步骤中，"SUFFIX"一词作为资源名称的一部分出现。应将其替换为 Microsoft 别名、首字母缩写或其他值，以确保资源唯一命名。

### 任务 1: 预配资源组

在此任务中，创建 Azure 资源组作为整个实验中使用的资源的容器。

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** from the Azure services list.

   ![Resource groups is highlighted in the Azure services list.](media/azure-services-resource-groups.png "Azure services")

2. On the Resource groups blade, select **+Add**.

   ![+Add is highlighted in the toolbar on Resource groups blade.](media/resource-groups-add.png "Resource groups")

3. On the Create a resource group **Basics** tab, enter the following:

   - **Subscription**: Select the subscription you are using for this hands-on lab.
   - **Resource group**: Enter **hands-on-lab-SUFFIX** as the name of the new resource group.
   - **Region**: Select the region you are using for this hands-on lab.

   ![The values specified above are entered into the Create a resource group Basics tab.](media/create-resource-group.png "Create resource group")

4. Select **Review + Create**.

5. On the **Review + create** tab, ensure the Validation passed message is displayed and then select **Create**.

### 任务 2：注册所需的资源提供程序

 
在此任务中，在 Azure 订阅中注册`Microsoft.DataMigration` 和 `Microsoft.Search` 资源提供程序。这些资源提供程序允许在订阅中预配 Azure 认知搜索和 Azure 数据库迁移服务。

1. In the [Azure portal](https://portal.azure.com), select **Subscriptions** from the Azure services list.

   ![Subscriptions is highlighted in the Azure services list.](media/azure-services-subscriptions.png "Azure services")

2. Select the subscription you are using for this hands-on lab from the list, select **Resource providers**, enter "migration" into the filter box, select **Microsoft.DataMigration** and then select **Register**.

   ![The Subscription blade is displayed, with Resource providers selected and highlighted under Settings. On the Resource providers blade, migration is entered into the filter box, and Register is highlighted next to Microsoft.DataMigration.](media/azure-portal-subscriptions-resource-providers-register-microsoft-datamigration.png "Resource provider registration")

3. It can take a couple of minutes for the registration to complete. Make sure you see a status of **Registered** before moving on. You may need to select **Refresh** to see the updated status.

   ![Registered is highlighted next to the Microsoft.DataMigration resource provider.](media/resource-providers-datamigration-registered.png "Microsoft DataMigration Resource Provider")

4. Next, enter "search" into the filter box to locate the `Microsoft.Search` resource provider. If the status is not **Registered**, select **Register**, and wait for the resource status to be registered.

   ![The Register button is highlighted, search is entered into the filter box, and the Microsoft.Search resource provider is selected.](media/resource-providers-search.png "Microsoft Search Resource Provider")

   > **Note**: You may need to select Refresh to see the updated status.

### 任务 3：运行 ARM 模板以预配实验室资源

在此任务中，运行 Azure 资源管理器 （ARM） 模板来部署和配置在整个动手操作实验室中使用的资源。ARM 模板创建的资源包括：

- Azure Blob Storage account
- A lab virtual machine (VM) with Visual Studio 2019 Community edition and SQL Server Management Studio (SSMS) installed.
- A SQL Server 2008 R2 VM with the Microsoft Data Migration Assistant (DMA) installed and a copy of the ContosoInsurance database installed.
- Azure SQL Database
- Azure Database Migration Service (DMS)
- Azure App Service Plan
- App Service (Web App)
- App Service (API App)
- Function App
- API Management
- Key Vault
- Azure Cognitive Search
- Azure Cognitive Services account
- Virtual Network

> **Note**: You can review the steps to manually provision the lab resources in the [Manual resource setup guide](./Manual-resource-setup.md).

1. To run the ARM template deployment, select the **Deploy to Azure** button below, which opens a custom deployment screen in the Azure portal.

<a href ="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fmicrosoft%2FMCW-App-modernization%2Fmaster%2FHands-on%20lab%2Flab-files%2FARM-template%2Fazure-deploy.json" target="_blank" title="Deploy to Azure">
<img src="http://azuredeploy.net/deploybutton.png"/>
</a>

2. On the custom deployment screen in the Azure portal, enter the following:

   - **Subscription**: Select the subscription you are using for this hands-on lab.
   - **Resource group**: Select the hands-on-lab-SUFFIX resource group from the dropdown list.
   - **Location**: Select the location you used for the hands-on-lab-SUFFIX resource group.
   - **SQL Server Name**: Accept the default value, **contosoinsurance**.


    > **Note**: The actual name must be globally unique, so a unique string is generated from your Resource Group Id and appended to the name during provisioning.

    - **Admin Username**: Accept the default value, **demouser**.
    - **Admin Password**: Accept the default value, **Password.1!!**.
    - **API Management Email**: Enter an email to use for admin notifications from API Management.
    - Check the box to agree to the Azure Marketplace terms and conditions.

    ![The Custom deployment blade displays, and the information above is entered on the Custom deployment blade.](media/azure-custom-deployment.png "Custom deployment blade")

3. Select **Purchase** to start provisioning the lab resources.

   > **Note**: The deployment of the custom ARM template takes about 30 minutes to complete. If you receive any errors, you can manually provision the missing resources following the steps within the [Manual resource setup guide](./Manual-resource-setup.md). If the error indicates an issue with quotas in the region you selected for the resource group, you can delete the resource group, create a new resource group in a different region, and re-run the ARM template, or you can request a quota increase and then manually provision the missing resources.

4. You can monitor the progress of the deployment by navigating to the hands-on-lab-SUFFIX resource group in the Azure portal and then selecting **Deployments** from the left-hand menu. The deployment should be named **Microsoft.Template**. Select the deployment item to view the progress of each individual component in the template.

   ![The Deployments menu item is selected in the left-hand menu of the hands-on-lab-SUFFIX resource group and the Microsoft.Template deployment is highlighted.](media/resource-group-deployments.png "Resource group deployments")

You should follow all steps provided _before_ attending the Hands-on lab.

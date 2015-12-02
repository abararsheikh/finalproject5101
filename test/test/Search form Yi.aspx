<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search form Yi.aspx.cs" Inherits="test.Search_form_Yi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/angular-animate.min.js"></script>
    <script src="Scripts/app.js"></script>
    <link href="css/search.css" rel="stylesheet" />
</head>
<body ng-controller="SearchController as search">
    <form id="form1" runat="server">
        <input class="searchBar" id="searchBox" type="text" placeholder="search.."
            ng-model="search.searchText" />
        <span class="leftborder"></span>
        <span class="rightborder"></span>
    </form>
    
    <div class="search-tabs">
        <input id="lblDoctors" type="radio" name="type" checked />
        <label for="lblDoctors" class="tab"
            ng-click="search.setList('doctors')"
            ng-class="{'tab-selected': search.currentList==='doctors'}">
            
            Doctors

        </label>

        <input id="lblPatients" type="radio" name="type" />
        <label for="lblPatients" class="tab"
            ng-click="search.setList('patients')"
            ng-class="{'tab-selected': search.currentList==='patients'}">
            
            Patients

        </label>
    </div>
    <ul>
        <li ng-repeat="person in search.list |
                    filter:search.searchFilter |
                    orderBy: search.f_name |
                    limitTo : search.limit"
            ng-click="search.toggleDetail(person)"
            ng-class="{'show-detail': person.showDetail}">

            <div class="brief">
                <p class="name">
                    {{person.f_name}} {{person.l_name}}
                </p>
                <p class="doctor-specialty"
                    ng-if="person.specialty"> 
                    
                    {{person.specialty}}

                </p>
            </div>

            <p class="description"
                ng-if="person.description">
                
                {{person.description}}

            </p>
        </li>
    </ul>
</body>
</html>

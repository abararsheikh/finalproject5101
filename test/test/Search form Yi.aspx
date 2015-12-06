﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search form Yi.aspx.cs" Inherits="test.Search_form_Yi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="doctorSearch">
<head runat="server">
    <title></title>

    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/angular-animate.min.js"></script>
    <script src="Scripts/app.js"></script>
    <link href="css/search.css" rel="stylesheet" />
</head>
<body ng-controller="SearchController as search">
    <div class="search">
        <form id="form1" runat="server">
            <input class="searchBar" id="searchBox" type="text" placeholder="search.."
                ng-model="search.searchText" />
            <span class="leftborder"></span>
            <span class="rightborder"></span>
        </form>

        <div class="search-tabs">
            <input id="lblDoctors" type="radio" name="type" checked="checked" />
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
        <div class="searchOptions">
            <input id="dateIn" type="checkbox" name="searchOption"
                ng-model="search.showDate"
                ng-click="search.showDate"
                ng-if="search.currentList=='patients'" />
            <label for="dateIn"
                ng-if="search.currentList=='patients'">
                admission date</label>
        </div>

        <ul>
            <p ng-if="search.isLoading">Loading..</p>

            <li ng-repeat="person in search.list |
                    filter:search.searchText |
                    orderBy: search.first_name"
                ng-click="search.toggleDetail(person)"
                ng-class="{'show-detail': person.showDetail}">

                <div class="brief">
                    <p class="name">
                        {{person.first_name}} {{person.last_name}}
                    </p>
                    <p class="doctor-specialty"
                        ng-if="person.speciality">
                        {{person.speciality}}

                    </p>
                    <p ng-if="search.showDate && person.date_in">Admission Date: {{person.date_in | date:longdate }}</p>

                </div>

                <div class="description">
                    <p>{{person.first_name}} {{person.last_name}}</p>
                    <p ng-show="person.phone">{{person.phone}}</p>
                    <p ng-show="person.office">Office: {{person.office}}</p>
                </div>
            </li>
        </ul>
    </div>
</body>
</html>

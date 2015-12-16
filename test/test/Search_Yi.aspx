<%@ Page MasterPageFile="~/BRDHC.Master" Language="C#" AutoEventWireup="true" CodeBehind="Search_Yi.aspx.cs" Inherits="test.Search_form_Yi" %>

    <asp:Content ContentPlaceHolderID="content" runat="server">
        <div class="search"
            ng-app="doctorSearch" ng-controller="SearchController as search">
        <form id="search" runat="server">
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
    </asp:Content>


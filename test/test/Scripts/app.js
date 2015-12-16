/**
* Author: Yi Zhao
*
* Description: A simple search written in angular.
*   
*/


(function () {
'use strict';

angular.module('doctorSearch', ['ngAnimate'])
.controller('SearchController', function ($http) {
    var search = this;
    
    /**
    * Sends a get request to getData.aspx to get data in selected table.
    * Shows the word "Loading..." when waiting for response.
    *
    * @param {String} listName   Table name that will be used in sql command
    */
    search.setList = function (listName) {
        search.currentList = listName;
        search.isLoading = true;
        $http({
            url: 'getData.aspx',
            method: 'GET',
            params: {
                t: listName
            }
        }).then(function (response) {
            search.isLoading = false;
            search.list = response.data;
        });
    };

    // Sets the default list to doctors when page loads.
    search.setList('doctors');

    search.searchText = '';

    // A show-detail toggle under patients table
    search.toggleDetail = function () {
        person.showDetail = !person.showDetail;
    };

    // Custom filter that only allows searching by first and last name.
    // Not in use.
    search.searchFilter = function (person) {
        if (search.searchText === ''){
            return true;
        }else{
            return person.first_name.toLowerCase().indexOf(search.searchText.toLowerCase()) !== -1 ||
                person.last_name.toLowerCase().indexOf(search.searchText.toLowerCase()) !== -1;
        }
    };
})





;
//end
})();

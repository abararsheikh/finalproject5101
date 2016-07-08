(function () {
'use strict';

angular.module('doctorSearch', ['ngAnimate'])
.controller('SearchController', function ($http) {
    var search = this;
    
    search.setList = function (listName) {
        search.currentList = listName;
        search.isLoading = true;
        $http({
            url: 'getData.aspx',
            method: 'GET',
            params: { t: listName }
        }).then(function (response) {
            search.isLoading = false;
            search.list = response.data;
        });
    };
    search.setList('doctors');

    search.searchText = '';
    search.toggleDetail = function (person) {
        person.showDetail = !person.showDetail;
    };
    search.searchFilter = function (person) {
        if (search.searchText === ''){
            return true;
        }else{
            return person.first_name.toLowerCase().indexOf(search.searchText.toLowerCase()) !== -1 ||
                person.last_name.toLowerCase().indexOf(search.searchText.toLowerCase()) !== -1;
        }
    };
});



//end
})();

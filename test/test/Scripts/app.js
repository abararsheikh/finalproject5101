(function () {
'use strict';

angular.module('doctorSearch', ['ngAnimate'])
.controller('SearchController', function () {
    var search = this;
    search.list = doctors;
    search.currentList = 'doctors';
    search.setList = function (type) {
        search.currentList = type;
        console.log(search.currentList);
        if(type === "doctors") search.list = doctors;
        if(type === "patients") search.list = patients;
    };

    search.searchText = '';
    search.limit = 20;
    search.showMore = function () {
        search.limit += 100;
    };
    search.toggleDetail = function (person) {
        person.showDetail = !person.showDetail;
    };
    search.searchFilter = function (person) {
        if (search.searchText === ''){
            return true;
        }else{
            return person.f_name.toLowerCase().indexOf(search.searchText.toLowerCase()) !== -1 ||
                person.l_name.toLowerCase().indexOf(search.searchText.toLowerCase()) !== -1;
        }
    };
});


var doctors = [
    {
        "f_name" : "Chaos",
        "l_name" : "Typhoon",
        "specialty" : "Allergy and Immunology",
        "id" : "1",
        "description" : "Immunology is a branch of biomedical science that covers the study of all aspects of the immune system in all organisms.[1] It deals with the physiological functioning of the immune system in states of both health and diseases; malfunctions of the immune system in immunological disorders (autoimmune diseases, hypersensitivities, immune deficiency, transplant rejection); the physical, chemical and physiological characteristics of the components of the immune system in vitro, in situ and in vivo. Immunology has applications in several disciplines of science, and as such is further divided."
    },
    {
        "f_name" : "Eternity",
        "l_name" : "Tombrogue",
        "specialty" : "Cardiology",
        "id" : "2",
        "description" : "Cardiology (from Greek καρδίᾱ kardiā, 'heart' and -λογία -logia, 'study') is a branch of medicine dealing with disorders of the heart be it human or animal. The field includes medical diagnosis and treatment of congenital heart defects, coronary artery disease, heart failure, valvular heart disease and electrophysiology. Physicians who specialize in this field of medicine are called cardiologists, a specialty of internal medicine. Pediatric cardiologists are pediatricians who specialize in cardiology. Physicians who specialize in cardiac surgery are called cardiothoracic surgeons or cardiac surgeons, a specialty of general surgery."
    },
    {
        "f_name" : "Katana",
        "l_name" : "Lancewitch",
        "specialty" : "General Practice",
        "id" : "3",
        "description": "In the medical profession, a general practitioner (GP) is a medical doctor who treats acute and chronic illnesses and provides preventive care and health education to patients."
    },
    {
        "f_name" : "Magus",
        "l_name" : "Queensoul",
        "specialty" : "Neurology",
        "id" : "4",
        "description" : "Neurology (from Greek: νεῦρον, neuron, and the suffix -λογία -logia 'study of') is a branch of medicine dealing with disorders of the nervous system. Neurology deals with the diagnosis and treatment of all categories of conditions and disease involving the central and peripheral nervous system (and its subdivisions, the autonomic nervous system and the somatic nervous system); including their coverings, blood vessels, and all effector tissue, such as muscle.[1] Neurological practice relies heavily on the field of neuroscience, which is the scientific study of the nervous system."
    },
    {
        "f_name" : "Totem",
        "l_name" : "Rougeguard",
        "specialty" : "Ophthalmology",
        "id" : "5",
        "description" : "Ophthalmology (/ˌɒfθɑːlˈmɑːlədʒi/ or /ˌɒpθɑːlˈmɒlədʒi/)[1] is the branch of medicine that deals with the anatomy, physiology and diseases of the eye.[2] An ophthalmologist is a specialist in medical and surgical eye problems. Since ophthalmologists perform operations on eyes, they are both surgical and medical specialists. A multitude of diseases and conditions can be diagnosed from the eye.[3]"
    }

];

var patients = [
    {
        "f_name" : "Helen",
        "l_name" : "Boitsova",
        "description" : "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Similique aliquam maiores sit beatae impedit doloribus eveniet nostrum tempora voluptates porro."
    },
    {
        "f_name" : "Miranda",
        "l_name" : "Gagnon",
        "description" : "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Similique aliquam maiores sit beatae impedit doloribus eveniet nostrum tempora voluptates porro."
    },
    {
        "f_name" : "Bin",
        "l_name" : "Liu",
        "description" : "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Similique aliquam maiores sit beatae impedit doloribus eveniet nostrum tempora voluptates porro."
    },
    {
        "f_name" : "Abarar",
        "l_name" : "Sheikh",
        "description" : "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Similique aliquam maiores sit beatae impedit doloribus eveniet nostrum tempora voluptates porro."
    },
    {
        "f_name" : "Yi",
        "l_name" : "Zhao",
        "description" : "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Similique aliquam maiores sit beatae impedit doloribus eveniet nostrum tempora voluptates porro."
    }
];

//end
})();

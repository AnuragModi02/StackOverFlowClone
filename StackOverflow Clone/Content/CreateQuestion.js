var element = document.querySelector('.TagsSuggestion')
var TagInput = document.querySelector('#Tags')
var HiddenTags = document.querySelectorAll(".input-tag")
var TagsInput = document.querySelector('.Tags-input')
let button = document.querySelector('.Submit');
var tagsdiv = document.querySelector('.hiddenTags');
//let closeTag = document.querySelector('.closetag')

var SelectedTags = [];

document.querySelector('.TagInput').value = "";
document.querySelector('.TagInput').addEventListener('click', function (){
    element.style.display = 'block'
})

element.addEventListener('click', function (e) {

    if (e.currentTarget != e.target) {

        SelectedTags.push(e.target.innerHTML);
      //  document.querySelector('.TagInput').value += e.target.innerHTML + " ";
        console.log(e.target.innerHTML)

        if (e.target.innerHTML == "C#") {
            HiddenTags[0].style.display = "flex";
        }
        if (e.target.innerHTML == "HTML") {
            HiddenTags[1].style.display = "flex";
        }
        if (e.target.innerHTML == "CSS") {
            HiddenTags[2].style.display = "flex";
        }
        if (e.target.innerHTML == "JavaScript") {
            HiddenTags[3].style.display = "flex";
        }
        setTimeout(function () {
            document.querySelector('.TagInput').focus();
        }, 1);

        TagsInput.style.border ='1px solid gray'
    }

})

button.addEventListener('click', function (e) {
    for (var tag of SelectedTags) {
        document.querySelector('.TagInput').value += tag + " ";
    }
    document.querySelector('.TagInput').style.color = 'white';
})

//for (var i = 0; i < HiddenTags.length; i++)
//{
//    HiddenTags[i].addEventListener('click', function (e) {

//    })
//}

tagsdiv.addEventListener('click', function (e) {

    console.log("clicked from hidden tags")
    if (e.target.classList.contains('closetag')) {

        if (e.target.parentNode.textContent.includes('C#')) {
            e.target.parentNode.style.display = "none";
            let index = SelectedTags.indexOf('C#')
            if (index > -1) {
                SelectedTags.splice(index, 1)
            }
            console.log(SelectedTags)
        }

        if (e.target.parentNode.textContent.includes('HTML')) {
            e.target.parentNode.style.display = "none";
            let index = SelectedTags.indexOf('HTML')
            if (index > -1) {
                SelectedTags.splice(index, 1)
            }
            console.log(SelectedTags)
        }

        if (e.target.parentNode.textContent.includes('CSS')) {
            e.target.parentNode.style.display = "none";
            let index = SelectedTags.indexOf('CSS')
            if (index > -1) {
                SelectedTags.splice(index, 1)
            }
            console.log(SelectedTags)
        }

        if (e.target.parentNode.textContent.includes('JavaScript')) {
            e.target.parentNode.style.display = "none";
            let index = SelectedTags.indexOf('JavaScript')
            if (index > -1) {
                SelectedTags.splice(index, 1)
            }
            console.log(SelectedTags)
        }


    }
})

//HiddenTags[0].addEventListener('click', function (e) {
//    console.log("clicked")
//})


//document.querySelector('.Tags-description').addEventListener('click', function (e) {
//    console.log("clicked from tag description")
//})

//document.querySelector('.Tags-input').addEventListener('click', function (e) {
//    console.log("clicked from tags-input")
//})
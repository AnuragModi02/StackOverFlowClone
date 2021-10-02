const TextArea = document.querySelector('.TextAreaForAnswer')
const button = document.querySelector('.YourAnswerButton')
const Url = button.dataset.requestUrl;
const questionId = button.dataset.questionid

function postAnswer() {
    event.preventDefault();

    const AnswerForQuestion = {
        QuestionId: questionId,
        Answer: TextArea.value
    }

    fetch(Url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(AnswerForQuestion),
    }).then(function (response) {
        console.log(response.json())
            window.location.reload()
        })
       .catch(error => console.log('error = ',error))
}

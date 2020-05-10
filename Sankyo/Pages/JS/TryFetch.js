fetch('/file.json')
    .then(response => response.json))
    .then(data => console.log(data))

fetch('./file.json')
    .then(response => {
        //...
    })
    .catch(err => console.error(err))

fetch('./file.json')
    .then(response => {
        if (!response.ok) {throw Error(response.statusText)}
    })
    .then(response => {
        //...
    })

fetch('./file.json').then(response => {
    console.log(response.headers.get('Content-Type'))
    console.log(response.headers.get('Date'))
})

fetch('')
    .then(response => {
        console.log(response.headers.get('Content-Type'))
        console.log(response.headers.get('Date'));
    })

fetch('./file.json').then(response => console.log(response.status))

fetch('./file.json').then(response => console.log(response.statusText))

fetch('./file.json').then(response => console.log(response.url))

fetch('./file.json')
    .then(response => response.text())
    .then(body => console.log(body))

fetch('./file.json')
    .then(response => response.json())
    .then(body => console.log(body))

fetch('./file.')

    ; (async () => {
        const response 
    })



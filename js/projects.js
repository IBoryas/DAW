const container = document.getElementById('container');
var currentProjectsId = null;

getPost();

async function getPost() {
    
    let res = await fetch(`https://localhost:7232/api/projects`)
    res = await res.json();
    addDataToDOM(res);
}

function addDataToDOM(data) {
    container.innerHTML = "";
    data.forEach(project => {
        const postElement = document.createElement('div');
        postElement.setAttribute('class','blog-post');
        postElement.setAttribute('id',`${project.id}`);
        postElement.innerHTML = `
        <h2 class="single">${project.name}</h2>
        <input type="button" value="Save" id="saveClient" class="save-btn"/>
        <h5 class="row"><i>${project.description}</i></h5>
        <div>
                  <div class="form-group">
                    <label>Signed date</label>
                    <input type="date" id="Signed" className="form-control" value="${project.id}" />
                  </div>
                  <div class="form-group">
                      <label>Start date</label>
                      <input type="date" id="Start" className="form-control" value="${project.id}" />
                  </div>
                  <div class="form-group">
                      <label>End date</label>
                      <input type="date" id="End" className="form-control" value="${project.id}" />
                  </div>
            </div>
            <div class="deals">
                <h3>Deals</h3>
                <ul id="deals">
                </ul>
            </div>
        `;
        // const dealsList = postElement.querySelector('#deals');
        // client.deals.forEach(deal => {
        //     // console.log(deal);
        //     var li = document.createElement("li");
        //     li.appendChild(document.createTextNode(deal));
        //     dealsList.appendChild(li);
        // });
        
        container.appendChild(postElement);
    });
    SetClients();
    SetSaves();
}
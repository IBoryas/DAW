const container = document.getElementById('container');
var currentDealId = null;
const newClients = document.getElementById('NewClient');
const newProjects = document.getElementById('NewProject');

getPost();
getClients(newClients);
getProjects(newProjects);

async function getProjects(elem)
{
    elem.innerHTML="<option value='null'></option>";
    let res = await fetch(`https://localhost:7232/api/projects/available`)
    res = await res.json();
    res.forEach(project => {
        const projElem = document.createElement('option');
        projElem.setAttribute('value',`${project.id}`);
        projElem.innerHTML = project.name;
        elem.appendChild(projElem);
    })
}

async function getClients(elem)
{
    let res = await fetch(`https://localhost:7232/api/clients/list`)
    res = await res.json();
    res.forEach(client => {
        const projElem = document.createElement('option');
        projElem.setAttribute('value',`${client.id}`);
        projElem.innerHTML = client.companyName;
        elem.appendChild(projElem);
    })
}

async function getPost() {
    
    let res = await fetch(`https://localhost:7232/api/deals`)
    res = await res.json();
    await addDataToDOM(res);
    SetDeals();
    SetSaves();
}

function FormatDate(date)
{
    var year = date.toLocaleString("default", { year: "numeric" });
    var month = date.toLocaleString("default", { month: "2-digit" });
    var day = date.toLocaleString("default", { day: "2-digit" });

    var formattedDate = year + "-" + month + "-" + day;
    return formattedDate;
}

async function addDataToDOM(data) {
    container.innerHTML = "";
    for (let x=0; x<data.length; x++){
        deal = data[x];
        // console.log(deal)
        const postElement = document.createElement('div');
        postElement.setAttribute('class','blog-post');
        postElement.setAttribute('id',`${deal.id}`);
        postElement.innerHTML = `
        <h2 class="single">${deal.name}</h2>
        <input type="button" value="Save" id="saveDeal" class="save-btn"/>
            <div>
                  <div class="form-group">
                    <label>Client</label>
                    <select type="text" id="Client" className="form-control">
                    </select>
                  </div>
                  <div class="form-group">
                      <label>Project</label>
                      <input type="text" id="Project" className="form-control" value="${deal.projectName}" disabled/>
                  </div>
            </div>
            <div>
                  <div class="form-group">
                    <label>Price per hour</label>
                    <input type="text" id="pricePerHour" className="form-control" value="${deal.pricePerHour}" />
                  </div>
                  <div class="form-group">
                      <label>Likelihood</label>
                      <input type="text" id="likelihood" className="form-control" value="${deal.likelihood}" />
                </div>
            </div>
            <div>
                  <div class="form-group">
                    <label>Start date</label>
                    <input type="date" id="prospectedStartDate" class="date" className="form-control" value="${FormatDate(new Date(deal.prospectedStartDate))}" />
                  </div>
                  <div class="form-group">
                      <label>Prospected hours</label>
                      <input type="text" id="prospectedHours" className="form-control" value="${deal.prospectedHours}" />
                  </div>
            </div>
        `;
        var client = postElement.querySelector('#Client')
        await getClients(client);
        client.value = deal.clientId;

        container.appendChild(postElement);
    };
}

function SetDeals()
{
    const deals = document.getElementsByClassName('blog-post');
    // console.log(deals.length);
    // console.log(deals);
    for (let x = 0; x < deals.length; x++) {
        deals[x].addEventListener("click",() => {
            var id= deals[x].id;
            if (currentDealId != id)
            {
                currentDealId = id;
                for (let y = 0; y < deals.length; y++){
                    deals[y].setAttribute('class','blog-post');
                }
                deals[x].className = 'blog-post current-post';
            }
        })
    }
}

function ChangesAreValid(a,b,c,d)
{
    return (a!="" && b!="" && c!="" && d!="");
}

function SetSaves()
{
    const btns = document.getElementsByClassName('save-btn');
    for (let x= 0; x<btns.length; x++){
        btns[x].addEventListener('click', async () => {
            id = btns[x].parentNode.id;
            deal = document.getElementById(id);
            price = deal.querySelector('#pricePerHour').value;
            like = deal.querySelector('#likelihood').value;
            date = deal.querySelector('#prospectedStartDate').value;
            hours = deal.querySelector('#prospectedHours').value;

                if (ChangesAreValid(price,like,date,hours))
                {
                    await fetch (`https://localhost:7232/api/deals/${id}`, {
                        method: "PUT",
                        headers: {
                            "Content-Type" : "application/json"
                            },
                        body: JSON.stringify(
                            {
                                "clientId": document.getElementById(id).querySelector('#Client').value,
                                "pricePerHour": price,
                                "likelihood": like,
                                "prospectedStartDate": date,
                                "prospectedHours": hours
                            }
                        )
                        })
                }
        })
    }
}

function FormReset()
{
    document.getElementById('NewName').value = "";
    document.getElementById('NewClient').value = "null";
    document.getElementById('NewProject').value = "";
    document.getElementById('Price').value = "";
    document.getElementById('Likelihood').value = "";
    document.getElementById('StartDate').value = "";
    document.getElementById('Hours').value = "";
}

function FormIsValid()
{
    var name = document.getElementById('NewName').value;
    var client = document.getElementById('NewClient').value;
    var project = document.getElementById('NewProject').value;
    var price = document.getElementById('Price').value;
    var likelihood = document.getElementById('Likelihood').value;
    var startDate = document.getElementById('StartDate').value;
    var hours = document.getElementById('Hours').value;
    return (name!="" && client!="null" &&
        project != "null" && price != "" &&
        likelihood != "" && startDate != "" &&
        hours != "");
}

document.getElementById('addDeal').addEventListener('click', async () => {
    if(FormIsValid())
    {
       await fetch (`https://localhost:7232/api/deals`, {
           method: "POST",
           headers: {
               "Content-Type" : "application/json"
               },
           body: JSON.stringify(
               {
                "name": document.getElementById('NewName').value,
                "clientId": document.getElementById('NewClient').value,
                "projectId": document.getElementById('NewProject').value,
                "pricePerHour": document.getElementById('Price').value,
                "likelihood": document.getElementById('Likelihood').value,
                "prospectedStartDate": document.getElementById('StartDate').value,
                "prospectedHours": document.getElementById('Hours').value
                }
            )
        })

       getPost();
       FormReset();
       getProjects(newProjects);
    }   
})

document.getElementById('delete').addEventListener('click', async () => {
    if (currentDealId != null)
    {
        var deal = document.getElementById(currentDealId);
        deal.parentNode.removeChild(deal)
        await fetch(`https://localhost:7232/api/deals/${currentDealId}`, { method: 'DELETE' });
        getProjects(newProjects);
    }
})
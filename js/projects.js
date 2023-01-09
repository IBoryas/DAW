const container = document.getElementById('container');
var currentProjectsId = null;

getPost();

async function getPost() {
    
    let res = await fetch(`https://localhost:7232/api/projects`)
    res = await res.json();
    addDataToDOM(res);
}

function FormatDate(date)
{
    var year = date.toLocaleString("default", { year: "numeric" });
    var month = date.toLocaleString("default", { month: "2-digit" });
    var day = date.toLocaleString("default", { day: "2-digit" });

    var formattedDate = year + "-" + month + "-" + day;
    return formattedDate;
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
        <div class = "row">
            <h5><i>${project.description}</i></h5>
            <h3>Employees</h3>
        </div>
        <div>
                  <div class="form-group">
                    <label>Signed date</label>
                    <input type="date" id="Signed" className="form-control" value="${FormatDate(new Date(project.signedDate))}" />
                  </div>
                  <div class="form-group">
                      <label>Start date</label>
                      <input type="date" id="Start" className="form-control" value="${FormatDate(new Date(project.startDate))}" />
                  </div>
                  <div class="form-group">
                      <label>End date</label>
                      <input type="date" id="End" className="form-control" value="${FormatDate(new Date(project.endDate))}" />
                  </div>
            </div>
            <div class="employees">
                <ul id="employees">
                </ul>
            </div>
        `;
        const employeesList = postElement.querySelector('#employees');
        project.employees.forEach(employee => {
            var li = document.createElement("li");
            li.appendChild(document.createTextNode(employee));
            employeesList.appendChild(li);
        });
        
        container.appendChild(postElement);
    });
    SetProjects();
    SetSaves();
}

function SetProjects()
{
    const projects = document.getElementsByClassName('blog-post');
    for (let x = 0; x < projects.length; x++) {
        projects[x].addEventListener("click",() => {
            var id= projects[x].id;
            if (currentProjectsId != id)
            {
                currentProjectsId = id;
                for (let y = 0; y < projects.length; y++){
                    projects[y].setAttribute('class','blog-post');
                }
                projects[x].className = 'blog-post current-post';
            }
        })
    }
}

function ChangesAreValid(a,b,c)
{
    return (a!="" && b!="" && c!="");
}

function SetSaves()
{
    const btns = document.getElementsByClassName('save-btn');
    for (let x= 0; x<btns.length; x++){
        btns[x].addEventListener('click', async () => {
            id = btns[x].parentNode.id;
            project = document.getElementById(id);
            signed = project.querySelector('#Signed').value;
            start = project.querySelector('#Start').value;
            end = project.querySelector('#End').value;

                if (ChangesAreValid(signed,start,end))
                {
                    await fetch (`https://localhost:7232/api/projects/${id}`, {
                        method: "PUT",
                        headers: {
                            "Content-Type" : "application/json"
                            },
                        body: JSON.stringify(
                            {
                                "signedDate": signed,
                                "startDate": start,
                                "endDate": end
                            }
                        )
                        })
                }
        })
    }
}


function FormIsValid()
{
    var a = document.getElementById('Name').value;
    var b = document.getElementById('Description').value;
    var c = document.getElementById('SignedDate').value;
    var d = document.getElementById('StartDate').value;
    var e = document.getElementById('EndDate').value;
    return (a!="" && b!="" && c!="" && d!="" && e!="");
}

function FormReset()
{
    document.getElementById('Name').value = "";
    document.getElementById('Description').value = "";
    document.getElementById('SignedDate').value = "";
    document.getElementById('StartDate').value = "";
    document.getElementById('EndDate').value = "";
}

document.getElementById('Add').addEventListener('click', async () => {
    if(FormIsValid())
    {
       await fetch (`https://localhost:7232/api/projects`, {
           method: "POST",
           headers: {
               "Content-Type" : "application/json"
               },
           body: JSON.stringify(
               {
               "name": document.getElementById('Name').value,
               "description": document.getElementById('Description').value,
               "signedDate": document.getElementById('SignedDate').value,
               "startDate": document.getElementById('StartDate').value,
               "endDate": document.getElementById('EndDate').value
               }
           )
           })

       getPost();
       FormReset();
    }   
})

document.getElementById('deleteProject').addEventListener('click', async () => {
    if (currentProjectsId != null)
    {
        var deal = document.getElementById(currentProjectsId);
        deal.parentNode.removeChild(deal)
        await fetch(`https://localhost:7232/api/projects/${currentProjectsId}`, { method: 'DELETE' });
    }
})
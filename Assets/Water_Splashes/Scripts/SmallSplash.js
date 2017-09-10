#pragma strict

var SmallSplash : GameObject;

private var splashFlag = 0;


function Start () 
{

    SmallSplash.SetActive(false);

}

function Update () {

    if (Input.GetButtonDown("Fire2"))
    {

        if (splashFlag == 0)
        {
            TriggerSplash();
        }
       
    }


    
}

   
function TriggerSplash()
{
    
    splashFlag = 1;
    
    SmallSplash.SetActive(true);

    yield WaitForSeconds (2.1);

    SmallSplash.SetActive(false);

    splashFlag = 0;

}




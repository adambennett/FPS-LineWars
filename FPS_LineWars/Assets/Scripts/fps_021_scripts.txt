//Jimmy Vegas Unity 5 Tutorial
//These scripts will animate your death zombie and create bulletholes



//The UPDATED EnemyScript:

var EnemyHealth : int = 10;
var TheZombie : GameObject;

function DeductPoints (DamageAmount : int) {
	EnemyHealth -= DamageAmount;
}

function Update () {
	if (EnemyHealth <= 0) {
		this.GetComponent("ZombieFollow").enabled=false;
		TheZombie.GetComponent.<Animation>().Play("Dying");
		EndZombie();
	}
}

function EndZombie () {
	yield WaitForSeconds(3);
	Destroy(gameObject);
}



//EXTRA section of the gun damage script:

if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), hit)) {
							Instantiate(TheBullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
						}
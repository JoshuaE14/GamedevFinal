using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die() //enemy death, destroy for now, room for death animation later
    {
        Destroy(gameObject);  
    }
}


/*
 To set up the provided `Weapon` and `Enemy` scripts in Unity, you need to follow these steps to integrate them into your project and make sure everything works smoothly.

### Step-by-step Setup:

#### 1. **Create the Weapon Script:**
- Create a new script in Unity and name it `Weapon.cs`.
- Copy and paste the provided `Weapon` script into this new script.
- Attach the `Weapon` script to the object that will act as the weapon in the scene (e.g., a sword, gun, or any other item the player can hold or interact with).

#### 2. **Create the Enemy Script:**
- Create a new script in Unity and name it `Enemy.cs`.
- Copy and paste the provided `Enemy` script into this new script.
- Attach the `Enemy` script to any GameObject in your scene that represents an enemy (e.g., a zombie, alien, etc.).

#### 3. **Assign Components in the Inspector:**
You’ll need to set up the `Weapon` script by assigning the `attackPoint` and `enemyLayer` references in the Unity Inspector.

- **Attack Point:**
  - Create an empty GameObject in the scene and position it at the place where the attack will be centered (e.g., the tip of a sword or gun barrel).
  - Drag this empty GameObject into the `Attack Point` field in the `Weapon` script.

- **Enemy Layer:**
  - Create a new layer for enemies by going to `Edit > Project Settings > Tags and Layers`, then add a new layer (e.g., "Enemy").
  - Assign this layer to all your enemy objects (GameObjects that have the `Enemy` script attached).
  - In the `Weapon` script, assign this layer to the `enemyLayer` field. To do this, just set the `LayerMask` to include the newly created "Enemy" layer.

#### 4. **Check the Inventory:**
The `InventoryHasWeapon()` method currently returns `true` by default. You might want to add logic here to check if the player actually has a weapon equipped.

For now, if you want to simulate this behavior, leave it as is. But later, you can integrate it with your inventory system to check if the player has a weapon.

#### 5. **Set up the `Attack()` method in the Weapon:**
- The `Attack()` method in the `Weapon` script uses `Physics.OverlapSphere()` to detect enemies within a given radius. This will work as long as there are colliders attached to the enemy objects in your scene.
- Ensure each enemy GameObject has a `Collider` (e.g., `BoxCollider`, `SphereCollider`) attached to it.

#### 6. **Test the Setup:**
- Play the scene in Unity.
- When you press the middle mouse button (`Input.GetMouseButtonDown(2)`), the `Attack()` method should trigger and check for enemies in the radius defined by `attackRange`.
- If enemies are within the range, they will take damage, and once their health is reduced to zero, they will be destroyed.

### Additional Enhancements:

1. **Adding Animations:**
   If you want to add animations, you can integrate them into the `Weapon` and `Enemy` scripts. For example, you could trigger an animation on the weapon when the attack occurs and an animation for the enemy when they die.

2. **Improving the Inventory Check:**
   If you have an inventory system, you can modify the `InventoryHasWeapon()` method to return `true` or `false` based on whether the player has a weapon in their inventory.

3. **Enemy Behavior:**
   You can expand the `Enemy` script to include more behaviors, like attacking back, patrolling, or even reacting to the player’s actions.

### Conclusion:
By following these steps, you will successfully set up the weapon and enemy scripts in Unity, with the weapon dealing damage to enemies when they are in range. You can further expand and customize these scripts to suit the gameplay mechanics you're aiming for!
*/




/*In Unity, a **LayerMask** is a way to filter which objects should be affected by certain operations based on their assigned layer. In the context of your `Weapon` script, the instruction to "assign this layer to the `enemyLayer` field" means that the `LayerMask` used in the script should be set to only include objects that are on the "Enemy" layer. This will ensure that the weapon's attack logic only affects objects designated as enemies, ignoring any other objects in the scene.

Here’s how you can set up the **LayerMask** for the `enemyLayer` field:

### Step-by-Step Process:
1. **Create the "Enemy" Layer:**
   - Go to `Edit` -> `Project Settings` -> `Tags and Layers`.
   - Under the `Layers` section, add a new layer called "Enemy."

2. **Assign the "Enemy" Layer to Enemy GameObjects:**
   - Select the GameObjects in your scene that represent enemies (the ones with the `Enemy` script attached).
   - In the **Inspector**, find the "Layer" dropdown at the top right.
   - Select the "Enemy" layer for these GameObjects.

3. **Set up `enemyLayer` in the `Weapon` Script:**
   - In the `Weapon` script, you have a `LayerMask` variable, which is called `Enemy`.
   - The `LayerMask` allows you to specify which layers should be included when detecting colliders. You can assign the "Enemy" layer to this mask.

### Example Code for the `Weapon` Script:
```csharp
public LayerMask enemyLayer;  // The LayerMask variable for enemy layer
```

### How to Assign the Layer Mask in the Unity Inspector:
1. After attaching the `Weapon` script to your weapon GameObject, select the weapon object in the **Hierarchy**.
2. In the **Inspector**, you'll see the `Weapon` script component, and you will see the `enemyLayer` field (which is a `LayerMask`).
3. Click on the dropdown next to `enemyLayer`. You'll see a list of layers that are available in the project.
4. **Check the box** next to the "Enemy" layer. This tells Unity that the weapon should interact only with objects that are on the "Enemy" layer.

### How It Works:
- The `Physics.OverlapSphere()` method checks for colliders in a sphere around the `attackPoint` and uses the `enemyLayer` to filter out only those colliders that are assigned to the "Enemy" layer.
- By setting the `enemyLayer` to include the "Enemy" layer, the `Weapon` script will only affect GameObjects that are actually enemies (i.e., those with the `Enemy` script and the "Enemy" layer), rather than interacting with all objects in the scene.

### Example:
Let’s say you have two objects in your scene:
- **Enemy1**: This GameObject is on the "Enemy" layer.
- **Obstacle**: This GameObject is on a different layer (not "Enemy").

When you perform an attack (using `Physics.OverlapSphere()`), only `Enemy1` will be affected because it’s on the "Enemy" layer, while `Obstacle` will be ignored, even if it’s within the range of the attack.

### Why is this useful?
This approach makes your game logic more efficient and flexible. Instead of your weapon affecting every object in the scene, the `LayerMask` ensures that only relevant GameObjects (in this case, enemies) are considered for damage, making the script more precise and performant.
*/

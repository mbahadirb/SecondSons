using System.Collections;

public enum ZombieStates {
	Idle,
	Waypoint,
	Pathfind,
	AttackGate,
	Attack
}

public enum EnemyStates {
	Idle,
	Waypoint,
	Pathfind,
	Attack
}

public enum Actions {
	Use,
	Break,
	Wield,
	Carry
}

public enum Orders {
	None,
	Attack,
	UseDoor,
	Loot,
	Break,
	Weld
}

public enum Ability {
	Idle = 0,
	Attack = 1,
	UseDoor = 2,
	Loot = 3,
	Heal = 4,
	Weld = 5,
	Use = 6
}


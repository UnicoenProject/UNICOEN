package Tree;

public class Main {
	public static void main(String[] args) {
		Node root = Node.createNode(10);
		insertNode(1, root);
		insertNode(15, root);
		insertNode(2, root);
		dumpTree(root, 0, "");

		if (search(2, root)) {
			System.out.println("found");
		}
		else {
			System.out.println("not found");
		}
	}

	// Insert node which has num as value into node
	public static void insertNode(int num, Node node) {
		if (node == null) {
			node = Node.createNode(num);
			return;
		}

		if (num < node.value) {
			if (node.left == null) {
				node.left = Node.createNode(num);
			}
			else {
				insertNode(num, node.left);
			}
		}
		else if (num > node.value) {
			if (node.right == null) {
				node.right = Node.createNode(num);
			}
			else {
				insertNode(num, node.right);
			}
		}

	}

	public static boolean search(int key, Node node) {
		if (node == null) {
			return false;
		}

		int value = node.value;
		// System.out.println("  "+value);
		// System.out.println("   " + key);
		if (key == value) {
			return true;
		}
		else {
			if (key < value) {
				// System.out.println("1");
				return search(key, node.left);
			}
			else {
				// System.out.println("2");
				return search(key, node.right);
			}
		}
	}
	
	public static void delete(int key, Node node){
		if(!search(key, node)){
			return;
		}
		else{
		}
	}

	public static void dumpTree(Node node, int indent, String mark) {
		if (node != null) {
			printSpacer(indent);

			if (mark.length() != 0) {
				System.out.print(mark + " : ");
			}
			System.out.print(node.value);
			System.out.println();

			dumpTree(node.right, indent + 1, "R");
			dumpTree(node.left, indent + 1, "L");

		}
	}

	public static void printSpacer(int indent) {
		while (indent-- > 0) {
			System.out.print(" ");
		}
	}
}

class Node {
	public int value;
	public Node left;
	public Node right;

	public static Node createNode(int num) {
		Node node = new Node();
		node.value = num;
		node.left = null;
		node.right = null;

		return node;
	}
}

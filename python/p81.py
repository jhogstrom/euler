import math
import string

INFINITY = 1000000000

class nodeinfo():	
	prevnode = None
	def __init__(self, x, y, value):
		# print "Making node", x, y, value
		self.nextnodes = []
		self.x = x
		self.y = y
		self.value = value
		self.dist = INFINITY
	def AddNode(self, node):
		# print "({0},{1}) Adding ({2},{3}) -- {4}".format(self.x, self.y, node.x, node.y, len(self.nextnodes))
		self.nextnodes.append(node)

# def AllNodes(node):
# 	result = [node,]
# 	for n in node.nextnodes:
# 		if not n in result:
# 			result += AllNodes(n)
# 	return result

def AllNodes(nodes):
	result = []
	for x in nodes:
		for y in x:
			result.append(y)
	return result

def printnode(node):
	print "({0},{1})[{2}] => {3}".format(node.x, node.y, node.value, len(node.nextnodes))

def GetMinimumDist(nodes):
	mindist = INFINITY
	res = None
	for n in nodes:
		# printnode(n)
		if n.dist < mindist:
			mindist = n.dist
			res = n
	return res


def Dijkstra(nodes, sourcenode, targetnodes):
	sourcenode.dist = sourcenode.value

	Q = AllNodes(nodes)
	
	while len(Q) > 0:
		u = GetMinimumDist(Q)
		# printnode(u)
		if u in targetnodes:
			return u
		Q.remove(u)
		for v in u.nextnodes:
			alt = u.dist + v.value
			if alt < v.dist:
				v.dist = alt
				v.prevnode = u


lines = open(r"matrix.txt").readlines()
# lines = open(r"smallmatrix.txt").readlines()

matrix =  [[int(n) for n in lines[i].split(",")] for i in range(len(lines))]

nodes = [[None for n in matrix[i]] for i in range(len(matrix))]

def MakeNode(x,y):	
	for x in xrange(len(nodes)):
		for y in xrange(len(nodes[x])):
			nodes[x][y] = nodeinfo(x, y, matrix[y][x])


	for x in xrange(len(nodes)):
		for y in xrange(len(nodes[x])):
			node = nodes[x][y]
			# Left node in matrix
			if x + 1 < len(matrix[y]): 
				node.AddNode(nodes[x+1][y])

			# Right node in matrix
			if x - 1 > 0: 
				if nodes[x-1][y]:
					node.AddNode(nodes[x-1][y])

			# Down node in matrix
			if y + 1 < len(matrix): 
				if nodes[x][y+1]:
					node.AddNode(nodes[x][y+1])

			# Up node in matrix
			if y - 1 >= 0: 
				if nodes[x][y-1]:
					node.AddNode(nodes[x][y-1])
	return nodes[x][y]

def MakeNode_Recursive(x, y):			
	res = nodeinfo(x, y, matrix[y][x])
	nodes[x][y] = res

	# Left node in matrix
	if x + 1 < len(matrix[y]): 
		if nodes[x+1][y]:
			res.AddNode(nodes[x+1][y])
		else:
			res.AddNode(MakeNode(x+1,y))

	# Right node in matrix
	if x - 1 > 0: 
		if nodes[x-1][y]:
			res.AddNode(nodes[x-1][y])
		else:
			res.AddNode(MakeNode(x-1,y))

	# Down node in matrix
	if y + 1 < len(matrix): 
		if nodes[x][y+1]:
			res.AddNode(nodes[x][y+1])
		else:
			res.AddNode(MakeNode(x,y+1))

	# Up node in matrix
	if y - 1 >= 0: 
		if nodes[x][y-1]:
			res.AddNode(nodes[x][y-1])
		else:
			res.AddNode(MakeNode(x,y-1))
	return res


s = MakeNode(0, 0)
start = nodes[0][1]

#p81
def p81():
	targets = [nodes[len(nodes)-1][len(nodes[len(nodes)-1])-1],]
	t = Dijkstra(nodes, s, targets)
	printnode(t)
	print t.dist

#p82
def p82():
	targets = [nodes[len(nodes)-1][i] for i in range(len(nodes[len(nodes)-1])-1)]

	mindist = INFINITY
	for y in xrange(len(nodes)-1):
		t = Dijkstra(nodes, nodes[0][y], targets)
		mindist=min(mindist,t.dist)

	print mindist

#p83
def p83():
	targets = [nodes[len(nodes)-1][len(nodes[len(nodes)-1])-1],]
	t = Dijkstra(nodes, nodes[0][0], targets)
	printnode(t)
	print "Mindist:",t.dist

# p81()
# p82()
p83()
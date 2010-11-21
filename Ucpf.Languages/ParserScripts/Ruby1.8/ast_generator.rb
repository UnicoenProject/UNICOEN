require 'ruby_parser'
require 'rexml/document'

@parser = RubyParser.new

def parse_code(text)
  ret = REXML::Document.new
  traverse(ret, @parser.parse(text.to_s))
  ret.root
end

def traverse(parent, exp)
  elem = REXML::Element.new(exp[0].to_s)
  elem.add_attribute('startline', exp.line)
  parent.add_element(elem)
  
  exp[1..-1].each_with_index do |t, i|
    case t
    when Sexp
      traverse(elem, t)
    when nil
      elem.add_element(REXML::Element.new('Nil'))
    else
      child = REXML::Element.new(t.class.to_s)
      child.add_text(t.to_s)
      elem.add_element(child)
    end
  end
end

print parse_code(STDIN.read()).to_s

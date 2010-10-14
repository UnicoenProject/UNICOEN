require 'ruby_parser'
require 'ruby2ruby'
require 'System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'

include System::Xml::Linq

class Ruby2Ruby
  def process_block(exp)
    #return [] if exp.empty?

    result = []

    exp << nil if exp.empty?
    until exp.empty? do
      code = exp.shift
      if code.nil? or code.first == :nil then
        result << 'nil'
      else
        result << process(code)
      end
    end

    result = result.join "\n"

    result = case self.context[1]
             when nil, :scope, :if, :iter, :resbody, :when, :while then
               result + "\n"
             else
               "(#{result})"
             end

    return result
  end
end

@parser = RubyParser.new
@r2r = Ruby2Ruby.new

def parse_code(text)
  ret = XDocument.new()
  traverse(ret, @parser.parse(text.to_s))
  ret.root
end

def traverse(parent, exp)
  with_element(parent, exp[0].to_s, exp.line) do |elem|
    exp[1..-1].each_with_index do |t, i|
      case t
      when Sexp
        traverse(elem, t)
      when nil
        elem.add(XElement.new(XName.get('Nil')))
      else
        elem.add(XElement.new(XName.get(t.class.to_s), t.to_s))
      end
    end
  end
end

def with_element(parent, name, line, &block)
  elem = XElement.new(XName.get(name))
  elem.set_attribute_value(XName.get('startline'), line)
  parent.add(elem)
  block.call(parent.last_node)
end

def parse_xml(root)
  @r2r.process(traverse_xml(root))
end

def traverse_xml(elem)
  arr = [elem.name.local_name.to_sym]
  for e in elem.elements
    ret = terminal_node2array_element(e)
    arr << (ret != false ? ret : traverse_xml(e))
  end
  arr
end

def terminal_node2array_element(elem)
  str = elem.name.local_name.to_s
  case elem.name.local_name
  when 'Nil'
    nil
  when 'Symbol'
    elem.value.to_sym
  when 'String'
    elem.value
  when 'Fixnum'
    elem.value.to_i
  when 'Bignum'
    elem.value.to_i
  when 'Float'
    elem.value.to_f
  else
    false
  end
end

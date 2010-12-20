# -*- coding: ascii-8bit -*-

require 'rubygems'
require 'ruby_parser'
require 'kconv'

p ["external", Encoding.default_external, "internal", Encoding.default_internal, "script", __ENCODING__, "locale", Encoding.find("locale")] if defined?(Encoding)
r = RubyParser.new
p r.parse(open("zkcount_08a2.rb", "r") { |f| f.read })
p 'ˆø”'
p Kconv.guess('ˆø”•\ƒ\ƒ“‚ ‚ ‚ ')

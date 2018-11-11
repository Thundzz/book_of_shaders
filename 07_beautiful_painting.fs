// Author @patriciogv - 2015
// http://patriciogonzalezvivo.com

#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

vec3 drawSquare(float left, float right, float up, float down, vec2 st, vec3 color)
{
    
    vec2 bl = step(vec2(left, down),st);       // bottom-left
	vec2 tr = step(vec2(1. - right, 1. - up),1.0-st);   // top-right
	return color * vec3(bl.x * bl.y * tr.x * tr.y);
}

void main(){
    vec2 st = gl_FragCoord.xy/u_resolution.xy;
    vec3 color = vec3(0.0);

    // bottom-left
	
    vec3 beige = vec3(239.,230.,212.)/255.;
    vec3 red = vec3(167.,32.,36.)/255.;
    vec3 blue = vec3(1.,95.,156.) / 255.;
    vec3 yellow = vec3(252.,196.,40.)/255.;

    color += drawSquare(0.,0.062,1.,.845, st, red);
    color += drawSquare(0.086,0.207,1.,.845, st, red);
    color += drawSquare(0.236,0.734,1.,.845, st, beige);
    color += drawSquare(0.762,0.947,1.,.845, st, beige);
    color += drawSquare(0.974,1.0,1.,.845, st, yellow);

    color += drawSquare(0.,0.062,0.814,.651, st, red);
    color += drawSquare(0.086,0.207,0.814,.651, st, red);
    color += drawSquare(0.236,0.734,0.814,.651, st, beige);
    color += drawSquare(0.762,0.947,0.814,.651, st, beige);
    color += drawSquare(0.974,1.0,0.814,.651, st, yellow);
    
    color += drawSquare(0.,0.207,0.621,.0, st, beige);
    
    color += drawSquare(0.236,0.734,0.621,.090, st, beige);
    color += drawSquare(0.762,0.947,0.621,.090, st, beige);
    color += drawSquare(0.974,1.0,0.621,.090, st, beige);

    color += drawSquare(0.236,0.734,0.064,.000, st, beige);
    color += drawSquare(0.762,0.947,0.064,.000, st, blue);
    color += drawSquare(0.974,1.0,0.064,.000, st, blue);

     
    gl_FragColor = vec4(color,1.0);
}

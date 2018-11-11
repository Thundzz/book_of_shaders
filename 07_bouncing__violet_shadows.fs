// Author @patriciogv - 2015
// http://patriciogonzalezvivo.com

#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

void main(){
	vec2 st = gl_FragCoord.xy/u_resolution;
    vec2 m = u_mouse/u_resolution;
    float pct = 0.0;

    
    float x = 0.5 + 0.1*cos(1.5*u_time);
    float y = 0.5 + 0.4*sin(3.*u_time);
    
    float x2 = 0.5 + 0.5*sin(1.5*u_time);
    float y2 = 0.5 + 0.33*cos(7.*u_time);
    
	pct = 1.5*distance(st,vec2(x,y)) * 3.*distance(st,vec2(x2, y2));
	

    vec3 color = clamp(vec3(0.0), vec3(0.999), vec3(pct)) * vec3(0.351,0.156,0.985) +
 vec3(0.099,0.062,0.235);

	gl_FragColor = vec4( color, 1.0 );
}

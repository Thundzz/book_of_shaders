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
    
    //x = m.x;
    //y = m.y;
    
    
    // a. The DISTANCE from the pixel to the center
	//pct = distance(st,vec2(0.4)) + distance(st,vec2(0.6));
	pct = 1.5*distance(st,vec2(x,y)) * 3.*distance(st,vec2(0.5));
	//pct = min(distance(st,vec2(x,y)),distance(st,vec2(0.6)));
	//pct = max(distance(st,vec2(x,y)),distance(st,vec2(0.6)));
	//pct = pow(distance(st,vec2(0.4,0.4)),distance(st,vec2(0.6,0.6)));
    //pct = pow(distance(st,vec2(x,y)),3.*distance(st,vec2(0.6,0.6)));
	
    // b. The LENGTH of the vector
    //    from the pixel to the center
    // vec2 toCenter = vec2(0.5)-st;
    // pct = length(toCenter);

    // c. The SQUARE ROOT of the vector
    //    from the pixel to the center
    // vec2 tC = vec2(0.5)-st;
    // pct = sqrt(tC.x*tC.x+tC.y*tC.y);

    vec3 color = vec3(pct) * vec3(0.463,0.976,0.985);

	gl_FragColor = vec4( color, 1.0 );
}

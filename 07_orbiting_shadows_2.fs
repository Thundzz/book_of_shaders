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
    
    float x2 = 0.5 + 0.1*sin(1.5*u_time);
    float y2 = 0.5 + 0.4*cos(3.*u_time);
    
    //x = m.x;
    //y = m.y;
    
    
    // a. The DISTANCE from the pixel to the center
	//pct = distance(st,vec2(0.4)) + distance(st,vec2(0.6));
	pct = 1.5*distance(st,vec2(x,y)) * 3.*distance(st,vec2(x2, y2));
	//pct = min(distance(st,vec2(x,y)),distance(st,vec2(0.6)));
	//pct = max(distance(st,vec2(x,y)),distance(st,vec2(0.6)));
	//pct = pow(distance(st,vec2(0.4,0.4)),distance(st,vec2(0.6,0.6)));
    //float pct2 = pow(distance(st,vec2(x,y)),3.*distance(st,vec2(0.5,0.45)));
	
    // b. The LENGTH of the vector
    //    from the pixel to the center
    // vec2 toCenter = vec2(0.5)-st;
    // pct = length(toCenter);

    // c. The SQUARE ROOT of the vector
    //    from the pixel to the center
    // vec2 tC = vec2(0.5)-st;
    // pct = sqrt(tC.x*tC.x+tC.y*tC.y);

    vec3 color = clamp(vec3(0.0), vec3(0.999), vec3(pct)) * vec3(0.463,0.976,0.985) +
 vec3(0.052,0.116,0.220);

	gl_FragColor = vec4( color, 1.0 );
}
